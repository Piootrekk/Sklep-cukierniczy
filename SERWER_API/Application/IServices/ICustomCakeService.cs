using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICustomCakeService
    {
        public Task<ServiceResponse<List<CustomCake>>> GetAllCustomCakes();
        public Task<ServiceResponse<List<CustomCake>>> GetAllUserCustomCakes();
        public Task<ServiceResponse<List<CustomCake>>> AddCustomCake(CustomCake customCake);
        public Task<ServiceResponse<List<CustomCake>>> UpdateCustomCake(CustomCake customCake);
        public Task<ServiceResponse<List<CustomCake>>> DeleteCustomCake(int id);
    }
}
