using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Application.IServices
{
    public interface ICustomCakeService
    {
        public Task<ServiceResponse<List<CustomCakeDTO>>> GetAllCustomCakes();
        public Task<ServiceResponse<List<CustomCake>>> AddCustomCake(string Description , string Name, decimal brutto, int[] ProductId);
        public Task<ServiceResponse<List<CustomCake>>> UpdateCustomCake(string Description, string Name, decimal brutto, int[] ProductId, int CakeId);
        public Task<ServiceResponse<List<CustomCake>>> DeleteCustomCake(int id);
        public Task<ServiceResponse<CustomCakeDTO>> GetCustomCakeByID(int ID);
    }
}
