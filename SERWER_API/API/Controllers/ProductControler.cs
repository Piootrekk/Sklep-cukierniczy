using Application.IServices;
using Application.Services;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductControler(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet("getall/", Name = "GetAllProducts")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllProducts()
        {
            var respone = await _productService.GetAllProducts();
            return Ok(respone);
        }

        [HttpPost("addproduct/", Name = "AddProduct")]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProduct(Product product)
        {

            var respone = await _productService.Create(product);
            return Ok(respone);
        }
    }
}
