using Application.IServices;
using Domain;
using Domain.DTO;
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

        public CustomCakeService(DataContext data) {  _data = data; }

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

        public async Task<ServiceResponse<List<CustomCakeDTO>>> GetAllCustomCakes()
        {
            //consider returning int[] products insted of string.
            var response = await _data.CustomCakes.Where(c => !c.IsDeleted).ToListAsync();
            var CakeList = new List<CustomCakeDTO>();

            foreach (var cake in response)
            {
                string[] words = cake.IngredientList.Split(";");
                int[] list=new int[words.Length - 1];
                
                for(int i=0;i<words.Length - 1;i++)
                {
                    list[i] = Convert.ToInt32(words[i]);
                }

                var Cake = new CustomCakeDTO
                {
                    Id = cake.Id,
                    Name = cake.Name,
                    Description = cake.Description,
                    PriceBrutto = cake.PriceBrutto,
                    IngredientList = list


                };
                CakeList.Add(Cake);
            }
            return new ServiceResponse<List<CustomCakeDTO>>
            {
                Value = CakeList,
            };
        }

        public async Task<ServiceResponse<CustomCakeDTO>> GetCustomCakeByID(int ID)
        {
            try
            {
                //consider returning int[] products insted of string.
                var response = await _data.CustomCakes.FirstOrDefaultAsync(x => x.Id == ID);

                string[] words = response.IngredientList.Split(";");
                int[] list = new int[words.Length-1];

                for (int i = 0; i < words.Length-1; i++)
                {
                    list[i] = Convert.ToInt32(words[i]);
                }

                var Cake = new CustomCakeDTO
                {
                    Id = response.Id,
                    Name = response.Name,
                    Description = response.Description,
                    PriceBrutto = response.PriceBrutto,
                    IngredientList = list


                };

                return new ServiceResponse<CustomCakeDTO>
                {
                    Value = Cake,
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<CustomCakeDTO>
                {
                    Success = false, ReturnMesage="An isue Acured"+ex.Message,
                };
            }
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
