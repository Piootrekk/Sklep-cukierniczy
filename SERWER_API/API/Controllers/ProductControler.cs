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

        [HttpGet("getalladmin/", Name = "GetAllAdminProducts")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllAdminProducts()
        {
            var respone = await _productService.GetAllAdminProducts();
            return Ok(respone);
        }

        [HttpPost("addproduct/", Name = "AddProduct")]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProduct(Product product)
        {

            var respone = await _productService.Create(product);
            return Ok(respone);
        }

        [HttpDelete("delete/", Name = "DeleteProduct")]
        public async Task<ActionResult<ServiceResponse<Product>>> DeleteProduct(int productId)
        {

            var respone = await _productService.Delete(productId);
            return Ok(respone);
        }

        [HttpGet("getbycategory/", Name = "GetProductByCategory")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByCategory(string Category)
        {
            var respone = await _productService.GetProductByCategory(Category);
            return Ok(respone);
        }

        [HttpGet("getbyId/", Name = "GetProductByID")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByID(int Id)
        {
            var respone = await _productService.GetProductByID(Id);
            return Ok(respone);
        }

        [HttpGet("getbyposition/", Name = "GetProductByPosition")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByPosition(string position)
        {
            var respone = await _productService.GetProductByPosition(position);
            return Ok(respone);
        }

        [HttpPut("update/", Name = "UpdateProduct")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> UpdateProduct(Product product, int Id)
        {
            var respone = await _productService.Update( product, Id);
            return Ok(respone);
        }

    }
}
