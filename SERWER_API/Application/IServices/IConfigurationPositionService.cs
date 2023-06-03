using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IConfigurationPositionService
    {
        public Task<ServiceResponse<List<ConfigurationPosition>>> GetAllConfigurationPositions();
        public Task<ServiceResponse<List<ConfigurationPosition>>> GetAllAdminConfigurationPositions();
        public Task<ServiceResponse<List<ConfigurationPosition>>> AddConfigurationPosition(ConfigurationPosition ConfigurationPosition);
        public Task<ServiceResponse<List<ConfigurationPosition>>> UpdateConfigurationPosition(ConfigurationPosition ConfigurationPosition);
        public Task<ServiceResponse<List<ConfigurationPosition>>> DeleteConfigurationPosition(int id);

    }
}
