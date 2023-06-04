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
    public class CustomCakeService : ICustomCakeService
    {
        private readonly DataContext _data;
        private readonly IProductService _productService;
        public CustomCakeService(DataContext data,IProductService productService) {  _data = data; _productService = productService; }

        public async Task<ServiceResponse<List<CustomCake>>> AddCustomCake(string Description, string Name, decimal brutto, int[] ProductId)
        {
            try
            {
                List<Product> products = new List<Product>();
                string List = "";
                foreach(var Id in ProductId)
                {
                    var p = await _data.Products.Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
                   products.Add(p);
                    List = List+Id+";";
                }
                var customCake = new CustomCake
                {
                    Description = Description,
                    Name = Name,
                    PriceBrutto = brutto,
                    Products = products,
                    IngredientList = List
                    
                };
                _data.CustomCakes.Add(customCake);
                await _data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<CustomCake>> { Success = false, ReturnMesage = "Failed To add The cake: [ " + ex.Message +" ]"};
            }
            return new ServiceResponse<List<CustomCake>> { Success = true , ReturnMesage="Added Custom Cake" };
        }
        public async Task<ServiceResponse<List<CustomCake>>> DeleteCustomCake(int id)
        {
            var cake = await _data.CustomCakes.FirstOrDefaultAsync(c => c.Id == id);

            if (cake == null)
            {
                return new ServiceResponse<List<CustomCake>>
                {
                    Success = false,
                    ReturnMesage = "Custom cake not found."
                };
            }
            cake.IsDeleted = true;
            _data.SaveChanges();
            return new ServiceResponse<List<CustomCake>>
            {
                Success = true,
                ReturnMesage = "Deleted"
            };
        }

        public async Task<ServiceResponse<List<CustomCake>>> GetAllCustomCakes()
        {
            var response = await _data.CustomCakes.Where(c => !c.IsDeleted).Include(p=>p.Products).ToListAsync();
            return new ServiceResponse<List<CustomCake>>
            {
                Value = response,
            };
        }

        public async Task<ServiceResponse<List<CustomCake>>> UpdateCustomCake(string Description, string Name, decimal brutto, int[] ProductId, int CakeId)
        {
           var Cake = await _data.CustomCakes.FirstOrDefaultAsync(x=>x.Id == CakeId);
            if (Cake == null)
            {
                return new ServiceResponse<List<CustomCake>>
                {
                    Success = false,
                    ReturnMesage = "Custom cake not found."
                };
            }
            try
            {
                var row =  _data.Database.ExecuteSqlRaw($"DELETE FROM CustomCakeProduct WHERE CustomCakesId LIKE {Cake.Id};");
                List<Product> products = new List<Product>();
                string List = "";
                foreach (var Id in ProductId)
                {
                    var p = await _data.Products.Include(p => p.Images).Include(b => b.Position).Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
                    products.Add(p);
                    List = List + Id + ";";
                }

                Cake.Name = Name;
                Cake.Description = Description;
                Cake.Products = products;
                Cake.PriceBrutto = brutto;
                Cake.IngredientList = List;



            }catch (Exception ex)
            {
                return new ServiceResponse<List<CustomCake>>
                {
                    Success = false,
                    ReturnMesage = "Error: "+ex.Message,
                };
            }
        

            _data.SaveChanges();
            return new ServiceResponse<List<CustomCake>>
            {
                Success = true,
                ReturnMesage = "Edited"
            };
        }
    }
}
