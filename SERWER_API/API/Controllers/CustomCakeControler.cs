using Application.IServices;
using Application.Services;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customcake")]
    [ApiController]
    public class CustomCakeControler : ControllerBase
    {
        private readonly ICustomCakeService _customCakeService;
        public CustomCakeControler(ICustomCakeService customCakeService) { _customCakeService = customCakeService; }

        [HttpGet("getall/", Name = "GetAllCustomCakes")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAllCustomCakes()
        {
            var respone = await _customCakeService.GetAllCustomCakes();
            return Ok(respone);
        }

        [HttpDelete("delete/{id}" , Name ="DeleteCustomCake")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> DeleteCustomCake(int id)
        {
            var result = await _customCakeService.DeleteCustomCake(id);
            return Ok(result);
        }

        [HttpPost("addcake/" , Name ="AddCustomCake")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> AddCustomCake(string Description, string Name, decimal brutto, int[] ProductId)
        {
            var result = await _customCakeService.AddCustomCake(Description,Name,brutto,ProductId);
            return Ok(result);
        }

        [HttpPut("editcustomcake/",Name ="EditCustomCake")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> EditCustomCake(string Description, string Name, decimal brutto, int[] ProductId, int CakeId)
        {
            var result = await _customCakeService.UpdateCustomCake(Description, Name, brutto, ProductId, CakeId);
            return Ok(result);
        }
    }
}
