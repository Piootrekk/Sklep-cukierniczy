using Application.IServices;
using Application.Services;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/shipmenttypes")]
    [ApiController]
    public class ShipmentTypeControler : ControllerBase
    {
        private readonly IShipingTypeService _ShipingTypeService;

        public ShipmentTypeControler(IShipingTypeService ShipingTypeService)
        {
            _ShipingTypeService = ShipingTypeService;
        }

        [HttpGet("getshipmenttypes/", Name = "GetAllShipmentTypes")]
        public async Task<ActionResult<ServiceResponse<List<ShipmentType>>>> GetAllShipmentTypes()
        {
            var respone = await _ShipingTypeService.GetAllShipmentTypes();
            return Ok(respone);
        }

        [HttpGet("adminget/")]
        public async Task<ActionResult<ServiceResponse<List<ShipmentType>>>> GetAdminShipmentTypes()
        {
            var result = await _ShipingTypeService.GetAllAdminShipmentTypes();
            return Ok(result);
        }

        [HttpDelete("admindelete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ShipmentType>>>> DeleteShipmentType(int id)
        {
            var result = await _ShipingTypeService.DeleteShipmentType(id);
            return Ok(result);
        }

        [HttpPost("adminpost/")]
        public async Task<ActionResult<ServiceResponse<List<ShipmentType>>>> AddShipmentType(ShipmentType ShipmentType)
        {
            var result = await _ShipingTypeService.AddShipmentType(ShipmentType);
            return Ok(result);
        }

        [HttpPut("adminput/")]
        public async Task<ActionResult<ServiceResponse<List<ShipmentType>>>> UpdateCategory(ShipmentType ShipmentType)
        {
            var result = await _ShipingTypeService.UpdateShipmentType(ShipmentType);
            return Ok(result);
        }

    }
}
