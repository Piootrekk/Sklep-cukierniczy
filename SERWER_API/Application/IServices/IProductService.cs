using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IProductService
    {
        public Task<ServiceResponse<List<Product>>> GetAllProducts();
        public Task<ServiceResponse<Product>> GetProductByID(int Id);

        // Dodanie wyszukiewarki w przyszłości.

        //public Task<ServiceResponse<ProductSearchResultDTO>> GetProductByCategory(string CategoryUrl, int PageNumber, int PageResults);
        //public Task<ServiceResponse<ProductSearchResultDTO>> SearchForProducts(string SearchText, int PageNumber, int PageResults, string Category);
        //public Task<ServiceResponse<List<string>>> SearchForSugestions(string Text, string Category);
        public Task<ServiceResponse<List<Product>>> GetAllAdminProducts();
        public Task<ServiceResponse<Product>> Create(Product product, int WhoId);
        public Task<ServiceResponse<Product>> Update(Product product, int WhoId);
        public Task<ServiceResponse<bool>> Delete(int productId);
    }
}
