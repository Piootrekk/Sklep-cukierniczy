using Application.IServices;
using Azure;
using Domain;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Persistence.DataContextFolder;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/autentication")]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutenticationService _AutenticationService;
        public AutenticationController(IAutenticationService autenticationService)
        {
            _AutenticationService= autenticationService;
        }
        [HttpPost("register/", Name = "RegisterAcount")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO registerDTO)
        {
            var result = await _AutenticationService.Register(
              new User
              {
                 Username = registerDTO.Username,
                 Email = registerDTO.Email,
                 PhoneNumber = registerDTO.PhoneNumber,
                 FirstName = registerDTO.FirstName,
                 LastName = registerDTO.LastName,
                 Localisation= new Localisation 
                 { 
                    StreetName = registerDTO.StreetName,
                    CityName = registerDTO.CityName,
                    HouseNumber = registerDTO.HouseNumber,
                    PostalCode = registerDTO.PostalCode,
                 }
              }, registerDTO.Password);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("login/", Name = "LoginToAcount")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin login)
        {
            var result = await _AutenticationService.Login(login.Username, login.Password);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("changeemail/", Name = "changeemail")]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangeEmail([FromBody] string newemail , string UserID)
        {
            //var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); //Set while craeting the token. Geting the user id/

            var response = await _AutenticationService.ChangeEmail(int.Parse(UserID), newemail);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("changenumber/", Name = "changenumber")]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangeNumber([FromBody] string newnumber, string UserID)
        {
            //var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var response = await _AutenticationService.ChangeNumber(int.Parse(UserID), newnumber);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("changepasword/", Name = "changepasword")]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePasword([FromBody] string newpasword, string UserID)
        {
            //var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _AutenticationService.ChangePassword(int.Parse(UserID), newpasword);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getuserdata/{id}", Name = "GetUserData")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> GetUserData(int id)
        {
            //var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _AutenticationService.GetUserByID(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("getallusers/", Name = "GetAllUsers")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> GetAllUsers()
        {
            var response = await _AutenticationService.GetAllUsers();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("editlocalisation/", Name = "EditLocalisation")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> EditLocalisation(int Id,Localisation localisation )
        {
            var response = await _AutenticationService.ChangeLocalisation(Id,localisation);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("getallroles/", Name = "GetAllRoles")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> GetAllRoles()
        {
            var respone = await _AutenticationService.GetAllRoles();
            return Ok(respone);
        }

        [HttpPost("addrole/", Name = "AddRole")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> AddRole(Role role)
        {
            var response = await _AutenticationService.CreateRole(role);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("editrole/", Name = "EditRole")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> EditRole(Role role)
        {
            var response = await _AutenticationService.UpdateRole(role);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("deleterole/{id}", Name = "DeleteRole")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> DeleteRole(int id)
        {
            var response = await _AutenticationService.DeleteRole(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
