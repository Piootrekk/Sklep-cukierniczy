using Application.IServices;
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



    }
}
