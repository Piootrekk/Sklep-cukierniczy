using Application.IServices;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/ConfigurationPosition")]
    public class ConfigurationPositionController : ControllerBase
    {
        private readonly IConfigurationPositionService  _configurationPositionService;

        public ConfigurationPositionController(IConfigurationPositionService configurationPositionService)
        {
            _configurationPositionService = configurationPositionService;
        }

        [HttpGet("getall/", Name = "GetAllConfigurationPosition")]
        public async Task<ActionResult<ServiceResponse<List<ConfigurationPosition>>>> GetAllConfigurationPosition()
        {
            var respone = await _configurationPositionService.GetAllConfigurationPositions();
            return Ok(respone);
        }

        [HttpGet("getalladmin/", Name = "GetAllAdminConfigurationPosition")]
        public async Task<ActionResult<ServiceResponse<List<ConfigurationPosition>>>> GetAllAdminConfigurationPosition()
        {
            var respone = await _configurationPositionService.GetAllAdminConfigurationPositions();
            return Ok(respone);
        }

        [HttpPost("addposition/", Name = "AddConfigurationPosition")]
        public async Task<ActionResult<ServiceResponse<List<ConfigurationPosition>>>> AddConfigurationPosition(ConfigurationPosition conf)
        {
            var respone = await _configurationPositionService.AddConfigurationPosition(conf);
            return Ok(respone);
        }

        [HttpPut("updateconfiguration/", Name = "UpdateConfigurationPosition")]
        public async Task<ActionResult<ServiceResponse<List<ConfigurationPosition>>>> UpdateConfigurationPosition(ConfigurationPosition conf)
        {
            var respone = await _configurationPositionService.UpdateConfigurationPosition(conf);
            return Ok(respone);
        }

        [HttpDelete("delete/{id}", Name = "deleteConfigurationPosition")]
        public async Task<ActionResult<ServiceResponse<List<ConfigurationPosition>>>> UpdateConfigurationPosition(int id)
        {
            var respone = await _configurationPositionService.DeleteConfigurationPosition(id);
            return Ok(respone);
        }
    }
}
