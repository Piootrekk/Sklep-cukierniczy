using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<List<Category>>> GetAllCategorysAsync();
        public Task<ServiceResponse<List<Category>>> GetAllAdminCategories();
        public Task<ServiceResponse<List<Category>>> AddCategory(Category category);
        public Task<ServiceResponse<List<Category>>> UpdateCategory(Category category);
        public Task<ServiceResponse<List<Category>>> DeleteCategory(int id);
    }
}
