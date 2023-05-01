using Application.IServices;
using Domain;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/autentication")]
    public class AutenticationControler : ControllerBase
    {
        private readonly IAutenticationService _AutenticationService;
        public AutenticationControler(IAutenticationService autenticationService)
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

        [HttpGet("getallroles/", Name = "GetAllRoles")]
        public async Task<ActionResult<ServiceResponse<List<Role>>>> GetAllRoles()
        {
            var respone = await _AutenticationService.GetAllRoles();
            return Ok(respone);
        }
    }
}
