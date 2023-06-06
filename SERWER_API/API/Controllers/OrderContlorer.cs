using Application.IServices;
using Application.Services;
using Domain.DTO;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderContlorer : ControllerBase
    {
        private readonly IOrderService _order;
        public OrderContlorer(IOrderService order) { _order = order; }

        [HttpPost("addorder/", Name = "AddOrder")]
        public async Task<ActionResult<ServiceResponse<List<bool>>>> AddOrder(OrderDTO orderDTO)
        {
            var result = await _order.CreateOrder(orderDTO);
            return Ok(result);
        }

    }
}
