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
    public class ShipingTypeService : IShipingTypeService
    {

        private readonly DataContext _data;

        public ShipingTypeService(DataContext data)
        {
            _data = data;
        }
        public async Task<ServiceResponse<List<ShipmentType>>> AddShipmentType(ShipmentType shipmentType)
        {
           _data.ShipmentTypes.Add(shipmentType);
            await _data.SaveChangesAsync();
            return await GetAllAdminShipmentTypes();
        }

        public async Task<ServiceResponse<List<ShipmentType>>> DeleteShipmentType(int id)
        {
            ShipmentType shipmentType = await GetShipmentTypeyById(id);
            if (shipmentType == null)
            {
                return new ServiceResponse<List<ShipmentType>>
                {
                    Success = false,
                    ReturnMesage = "Category not found."
                };
            }

            shipmentType.IsDeleted = true;
            await _data.SaveChangesAsync();

            return await GetAllAdminShipmentTypes();
        }

        public async Task<ServiceResponse<List<ShipmentType>>> GetAllAdminShipmentTypes()
        {
            var response = await _data.ShipmentTypes.Where(c => !c.IsDeleted).ToListAsync();
            return new ServiceResponse<List<ShipmentType>>
            {
                Value = response,
            };
        }

        public async Task<ServiceResponse<List<ShipmentType>>> GetAllShipmentTypes()
        {
            var response = await _data.ShipmentTypes.Where(c => !c.IsDeleted && c.IsActive).ToListAsync();
            return new ServiceResponse<List<ShipmentType>>
            {
                Value = response,
            };
        }

        public async Task<ServiceResponse<List<ShipmentType>>> UpdateShipmentType(ShipmentType shipmentType)
        {
            var dbCategory = await GetShipmentTypeyById(shipmentType.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<ShipmentType>>
                {
                    Success = false,
                    ReturnMesage = "Category not found."
                };
            }

            dbCategory.Name = shipmentType.Name;
            dbCategory.IsActive = shipmentType.IsActive;

            await _data.SaveChangesAsync();

            return await GetAllAdminShipmentTypes();
        }

        private async Task<ShipmentType> GetShipmentTypeyById(int id)
        {
            return await _data.ShipmentTypes.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
