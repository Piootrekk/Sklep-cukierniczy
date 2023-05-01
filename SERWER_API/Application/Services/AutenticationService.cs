using Application.IServices;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly DataContext _data;
        public AutenticationService(DataContext data)
        {
            _data = data;
        }

        public Task<ServiceResponse<bool>> ChangeEmail(int userId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> ChangeFirstName(int userId, string newFirstName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> ChangeLastName(int userId, string newLastName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> ChangeLocalisation(int userId, string adres)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> ChangeNumber(int userId, string newNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            throw new NotImplementedException();
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

        public Task<ServiceResponse<User>> GetUserByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> Login(string Username, string password)
        {
            throw new NotImplementedException();
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

        public async Task<bool> UserExistsUsername(string Username)
        {
            if (await _data.Users.AnyAsync(user => user.Username.ToLower()
                 .Equals(Username.ToLower())))
            {
                return true;
            }
            return false;
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
