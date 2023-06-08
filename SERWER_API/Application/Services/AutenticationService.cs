using Application.IServices;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContextFolder;
using System.Security.Cryptography;

namespace Application.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly DataContext _data;
        private readonly IJwtUtils _jwtUtils;

        public AutenticationService(DataContext data, IJwtUtils jwtUtils)
        {
            _data = data;
            _jwtUtils = jwtUtils;
        }

        public async Task<ServiceResponse<bool>> ChangeEmail(int userId, string newEmail)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            user.Email = newEmail;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "Email has been changed." };
        }

        public async Task<ServiceResponse<bool>> ChangeFirstName(int userId, string newFirstName)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            user.FirstName = newFirstName;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "FirstName has been changed." };
        }

        public async Task<ServiceResponse<bool>> ChangeLastName(int userId, string newLastName)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            user.LastName = newLastName;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "LastName has been changed." };
        }

        public async Task<ServiceResponse<bool>> ChangeLocalisation(int userId, Localisation localisation)
        {
            var User = await _data.Users.Include(p=>p.Localisation).FirstOrDefaultAsync(x => x.Id == userId);
            if (User == null )
            {
                return new ServiceResponse<bool> { Success = false, ReturnMesage = "Found no user" };
            }
            if(User.Localisation==null)
            {
                User.Localisation = localisation;
                await _data.SaveChangesAsync();

                return new ServiceResponse<bool> { Success = true, ReturnMesage = "Localisation Changed" };
            }
            else
            {
                int oldid = User.Localisation.Id;
                User.Localisation = localisation;

                var oldLocalisation = await _data.Localisations.FirstOrDefaultAsync(x => x.Id == oldid);
                _data.Localisations.Remove(oldLocalisation);
                await _data.SaveChangesAsync();
            }
            return new ServiceResponse<bool> { Success = true, ReturnMesage = "Localisation Changed" };

        }

        public async Task<ServiceResponse<bool>> ChangeNumber(int userId, string newNumber)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            user.PhoneNumber = newNumber;

            await _data.SaveChangesAsync();
            return new ServiceResponse<bool> { Value = true, Success = true, ReturnMesage = "PhoneNumber has been changed." };
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _data.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    ReturnMesage = "User not found."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _data.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Value = true,
                Success = true,
                ReturnMesage = "Password has been changed."
            };
        }

        public async Task<ServiceResponse<int>> CreateRole(Role role)
        {
            await _data.AddAsync(role);
            await _data.SaveChangesAsync();

            return new ServiceResponse<int> {  Success = true, ReturnMesage = "Role added!" };
        }

        public async Task<ServiceResponse<Role>> DeleteRole(int RoleId)
        {
            Role role;
            try
            {
                 role = await _data.Roles.FindAsync(RoleId);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Role> { Success = false, ReturnMesage = "no such role! Error" };
            }
            if (role == null)
                return new ServiceResponse<Role> { Success = false, ReturnMesage = "no such role!" };

            role.IsDeleted = true;
            await _data.SaveChangesAsync();

            return new ServiceResponse<Role> { Success = true, ReturnMesage = "Role Deleted" };
        }

        public async Task<ServiceResponse<Role>> UpdateRole(Role role)
        {
            var Role = await _data.Roles.FirstOrDefaultAsync(x=>x.Id==role.Id);
            if (Role == null)
                return new ServiceResponse<Role> { Success = false, ReturnMesage = "no such role!" };

            Role.Name = role.Name;
            Role.Level = role.Level;
            Role.IsDeleted = role.IsDeleted;
            Role.IsActive = role.IsActive;

            await _data.SaveChangesAsync();
            return new ServiceResponse<Role> { Value=Role, Success = true, ReturnMesage = "role updated" };
        }

        public async Task<ServiceResponse<List<Role>>> GetAllRoles()
        {
            var response = await _data.Roles.ToListAsync();
            return new ServiceResponse<List<Role>>
            {
                Value = response,
                Success = true,
            };
        }

        public async Task<ServiceResponse<User>> GetUserByID(int Id)
        {
            var User = await _data.Users.Include(p=>p.Role).Include(b=>b.Localisation).FirstOrDefaultAsync(x => x.Id == Id);
            if (User == null)
            {
                return new ServiceResponse<User> { Value = null, Success = false, ReturnMesage = "Found no user" };
            }
            return new ServiceResponse<User> { Value = User, Success = true, ReturnMesage = "Found the user" };
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
            var User = await _data.Users.Include(p => p.Role).Include(b => b.Localisation).ToListAsync();
            if (User == null)
            {
                return new ServiceResponse<List<User>> { Value = null, Success = false, ReturnMesage = "Found no users" };
            }
            return new ServiceResponse<List<User>> { Value = User, Success = true, ReturnMesage = "Found the users" };
        }

        public async Task<ServiceResponse<string>> Login(string Username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _data.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == Username.ToLower());
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.ReturnMesage = "Bad Username or Login";
            }
            else
            {

                response.ReturnMesage = _jwtUtils.GenerateJwtToken(user);
                response.Success = true;
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExistsEmail(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    ReturnMesage = "User with that Email already exists."
                };
            }

            if (await UserExistsUsername(user.Username))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    ReturnMesage = "User with that Username already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if(user.Role==null) 
            { 
                user.Role= await _data.Roles.FirstOrDefaultAsync(x=>x.Name == "User"); 
            }

            _data.Users.Add(user);
            await _data.SaveChangesAsync();

            return new ServiceResponse<int> { Value = user.Id, Success = true, ReturnMesage = "Registration successful!" };
        }

        public Task<ServiceResponse<bool>> ResetPasword(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExistsEmail(string Email)
        {
            if (await _data.Users.AnyAsync(user => user.Email.ToLower()
                 .Equals(Email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public Task<bool> UserExistsUsername(string Username)
        {
            return _data.Users.AnyAsync(user => user.Username.ToLower()
                             .Equals(Username.ToLower()));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
