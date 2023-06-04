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
    public class ConfigurationPositionService : IConfigurationPositionService
    {
        private readonly DataContext _data;

        public ConfigurationPositionService(DataContext data)
        {
            _data = data;
        }
        public async Task<ServiceResponse<List<ConfigurationPosition>>> AddConfigurationPosition(ConfigurationPosition configurationPosition)
        {
           _data.ConfigurationPositions.Add(configurationPosition);
            await _data.SaveChangesAsync();
            return await GetAllAdminConfigurationPositions();
        }

        public async Task<ServiceResponse<List<ConfigurationPosition>>> DeleteConfigurationPosition(int id)
        {
            var position = _data.ConfigurationPositions.FirstOrDefault(x => x.Id == id);
            if (position == null)
            {
                return new ServiceResponse<List<ConfigurationPosition>>
                {
                    Success = false,
                    ReturnMesage = "Configuration Position not found."
                };
            }

            position.IsDeleted = true;
            await _data.SaveChangesAsync();

            return await GetAllAdminConfigurationPositions();
        }

        public async Task<ServiceResponse<List<ConfigurationPosition>>> GetAllAdminConfigurationPositions()
        {
            var response = await _data.ConfigurationPositions.Where(c => !c.IsDeleted).ToListAsync();
            return new ServiceResponse<List<ConfigurationPosition>>
            {
                Value = response
            };
        }

        public async Task<ServiceResponse<List<ConfigurationPosition>>> GetAllConfigurationPositions()
        {
            var response = await _data.ConfigurationPositions.Where(c => !c.IsDeleted && c.IsActive).ToListAsync();
            return new ServiceResponse<List<ConfigurationPosition>>
            {
                Value = response
            };
        }

        public async Task<ServiceResponse<List<ConfigurationPosition>>> UpdateConfigurationPosition(ConfigurationPosition configurationPosition)
        {
            var position = _data.ConfigurationPositions.FirstOrDefault(x => x.Id == configurationPosition.Id);
            if (position == null)
            {
                return new ServiceResponse<List<ConfigurationPosition>>
                {
                    Success = false,
                    ReturnMesage = "Configuration Position not found."
                };
            }

            position.Placement= configurationPosition.Placement;
            position.Name = configurationPosition.Name;
            position.IsActive = configurationPosition.IsActive;
            position.IsDeleted = configurationPosition.IsDeleted;

            await _data.SaveChangesAsync();

            return await GetAllAdminConfigurationPositions();
        }
    }
}
