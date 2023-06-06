using Application.IServices;
using Application.Services;
using Domain.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.DTO;

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
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetAllProducts()
        {
            var respone = await _productService.GetAllProducts();
            return Ok(respone);
        }
        [HttpGet("getallingridients/", Name = "GetAllIngridients")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetAllIngridients()
        {
            var respone = await _productService.GetIngridients();
            return Ok(respone);
        }

        [HttpGet("getingridientsbyposition/", Name = "GetAllIngridientsByPosition")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetAllIngridientsByPosition(string position)
        {
            var respone = await _productService.GetIngridientsByPosition(position);
            return Ok(respone);
        }

        [HttpGet("getalladmin/", Name = "GetAllAdminProducts")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetAllAdminProducts()
        {
            var respone = await _productService.GetAllAdminProducts();
            return Ok(respone);
        }

        [HttpPost("addproduct/", Name = "AddProduct")]
        public async Task<ActionResult<ServiceResponse<ProductDTO>>> AddProduct(ProductDTO product)
        {
            
            var respone = await _productService.Create(product);
            return Ok(respone);
        }

        [HttpDelete("delete/", Name = "DeleteProduct")]
        public async Task<ActionResult<ServiceResponse<ProductDTO>>> DeleteProduct(int productId)
        {

            var respone = await _productService.Delete(productId);
            return Ok(respone);
        }

        [HttpGet("getbycategory/", Name = "GetProductByCategory")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetProductByCategory(string Category)
        {
            var respone = await _productService.GetProductByCategory(Category);
            return Ok(respone);
        }

        [HttpGet("getbyId/", Name = "GetProductByID")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetProductByID(int Id)
        {
            var respone = await _productService.GetProductByID(Id);
            return Ok(respone);
        }

        [HttpGet("getbyposition/", Name = "GetProductByPosition")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> GetProductByPosition(string position)
        {
            var respone = await _productService.GetProductByPosition(position);
            return Ok(respone);
        }

        [HttpPut("update/", Name = "UpdateProduct")]
        public async Task<ActionResult<ServiceResponse<List<ProductDTO>>>> UpdateProduct(ProductDTO product)
        {
            var respone = await _productService.Update( product, product.Id);
            return Ok(respone);
        }

    }
}
