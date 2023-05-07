using Application.IServices;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly DataContext _data;

        public CategoryService(DataContext data)
        {
            _data = data;
        }
        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            _data.Categorys.Add(category);
            await _data.SaveChangesAsync();
            return await GetAllAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    ReturnMesage = "Category not found."
                };
            }

            category.IsDeleted = true;
            await _data.SaveChangesAsync();

            return await GetAllAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> GetAllAdminCategories()
        {
            var response = await _data.Categorys.Where(c => !c.IsDeleted).ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Value = response
            };
        }

        public async Task<ServiceResponse<List<Category>>> GetAllCategorysAsync()
        {
            var response = await _data.Categorys.Where(c => !c.IsDeleted && c.IsActive).ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Value = response,
            };
        }

        public async Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    ReturnMesage = "Category not found."
                };
            }

            dbCategory.Name = category.Name;
            dbCategory.IsActive = category.IsActive;

            await _data.SaveChangesAsync();

            return await GetAllAdminCategories();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            return await _data.Categorys.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
