using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain.DTO;

namespace Application.IServices
{
    public interface IProductService
    {
        public Task<ServiceResponse<List<ProductDTO>>> GetAllProducts();
        public Task<ServiceResponse<ProductDTO>> GetProductByID(int Id);
        public Task<ServiceResponse<List<ProductDTO>>> GetProductByCategory(string Category);
        public Task<ServiceResponse<List<ProductDTO>>> GetProductByPosition(string position);
        public Task<ServiceResponse<List<ProductDTO>>> GetIngridients();
        public Task<ServiceResponse<List<ProductDTO>>> GetIngridientsByPosition(string position);
        public Task<ServiceResponse<List<ProductDTO>>> GetAllAdminProducts();
        public Task<ServiceResponse<ProductDTO>> Create(ProductDTO product);
        public Task<ServiceResponse<ProductDTO>> Update(ProductDTO product , int Id);
        public Task<ServiceResponse<bool>> Delete(int productId);

        // Dodanie wyszukiewarki w przyszłości.
        //public Task<ServiceResponse<ProductSearchResultDTO>> SearchForProducts(string SearchText, int PageNumber, int PageResults, string Category);
        //public Task<ServiceResponse<List<string>>> SearchForSugestions(string Text, string Category);
    }
}
