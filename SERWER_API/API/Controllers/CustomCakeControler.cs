using Application.IServices;
using Application.Services;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using API.Requests.CustomCake;

namespace API.Controllers
{
    [Route("api/customcake")]
    [ApiController]
    public class CustomCakeControler : ControllerBase
    {
        private readonly ICustomCakeService _customCakeService;
        public CustomCakeControler(ICustomCakeService customCakeService) { _customCakeService = customCakeService; }

        [HttpGet("getall/", Name = "GetAllCustomCakes")]
        public async Task<ActionResult<ServiceResponse<List<CustomCakeDTO>>>> GetAllCustomCakes()
        {
            var respone = await _customCakeService.GetAllCustomCakes();
            return Ok(respone);
        }

        [HttpGet("getbyid/", Name = "GetCustomCakeByID")]
        public async Task<ActionResult<ServiceResponse<List<CustomCakeDTO>>>> GetCustomCakeByID(int id)
        {
            var respone = await _customCakeService.GetCustomCakeByID(id);
            return Ok(respone);
        }

        [HttpDelete("delete/{id}" , Name ="DeleteCustomCake")]
        public async Task<ActionResult<ServiceResponse<List<CustomCakeDTO>>>> DeleteCustomCake(int id)
        {
            var result = await _customCakeService.DeleteCustomCake(id);
            return Ok(result);
        }

        [HttpPost("addcake/" , Name ="AddCustomCake")]
        public async Task<ActionResult<ServiceResponse<List<CustomCakeDTO>>>> AddCustomCake(AddCustomCakeRequest cakeDTO)
        {
            var result = await _customCakeService.AddCustomCake(cakeDTO.Description, cakeDTO.Name, cakeDTO.PriceBrutto, cakeDTO.IngredientList);
            return Ok(result);
        }

        [HttpPut("editcustomcake/",Name ="EditCustomCake")]
        public async Task<ActionResult<ServiceResponse<List<CustomCakeDTO>>>> EditCustomCake(CustomCakeDTO cakeDTO)
        {
            var result = await _customCakeService.UpdateCustomCake(cakeDTO.Description, cakeDTO.Name, cakeDTO.PriceBrutto, cakeDTO.IngredientList,cakeDTO.Id);
            return Ok(result);
        }
    }
}
