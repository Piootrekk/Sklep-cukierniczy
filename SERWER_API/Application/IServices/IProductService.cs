using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.IServices
{
    public interface IProductService
    {
        public Task<ServiceResponse<List<Product>>> GetAllProducts();
        public Task<ServiceResponse<Product>> GetProductByID(int Id);
        public Task<ServiceResponse<List<Product>>> GetProductByCategory(string Category);
        public Task<ServiceResponse<List<Product>>> GetProductByPosition(string position);
        public Task<ServiceResponse<List<Product>>> GetAllAdminProducts();
        public Task<ServiceResponse<Product>> Create(Product product);
        public Task<ServiceResponse<Product>> Update(Product product);
        public Task<ServiceResponse<bool>> Delete(int productId);

        // Dodanie wyszukiewarki w przyszłości.
        //public Task<ServiceResponse<ProductSearchResultDTO>> SearchForProducts(string SearchText, int PageNumber, int PageResults, string Category);
        //public Task<ServiceResponse<List<string>>> SearchForSugestions(string Text, string Category);
    }
}
