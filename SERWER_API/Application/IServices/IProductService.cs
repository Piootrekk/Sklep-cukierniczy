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
        public Task<ServiceResponse<List<Product>>> GetAllProducts();
        public Task<ServiceResponse<Product>> GetProductByID(int Id);
        public Task<ServiceResponse<List<Product>>> GetProductByCategory(string Category);
        public Task<ServiceResponse<List<Product>>> GetProductByPosition(string position);
        public Task<ServiceResponse<List<Product>>> GetIngridients();
        public Task<ServiceResponse<List<Product>>> GetIngridientsByPosition(string position);
        public Task<ServiceResponse<List<Product>>> GetAllAdminProducts();
        public Task<ServiceResponse<Product>> Create(ProductDTO product);
        public Task<ServiceResponse<Product>> Update(ProductDTO product , int Id);
        public Task<ServiceResponse<bool>> Delete(int productId);

        // Dodanie wyszukiewarki w przyszłości.
        //public Task<ServiceResponse<ProductSearchResultDTO>> SearchForProducts(string SearchText, int PageNumber, int PageResults, string Category);
        //public Task<ServiceResponse<List<string>>> SearchForSugestions(string Text, string Category);
    }
}
