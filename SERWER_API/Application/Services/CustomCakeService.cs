using Application.IServices;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomCakeService : ICustomCakeService
    {
        public Task<ServiceResponse<List<CustomCake>>> AddCustomCake(CustomCake customCake)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CustomCake>>> DeleteCustomCake(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CustomCake>>> GetAllCustomCakes()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CustomCake>>> GetAllUserCustomCakes()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CustomCake>>> UpdateCustomCake(CustomCake customCake)
        {
            throw new NotImplementedException();
        }
    }
}
