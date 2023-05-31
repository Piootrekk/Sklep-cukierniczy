using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IShipingTypeService
    {
        public Task<ServiceResponse<List<ShipmentType>>> GetAllShipmentTypes();
        public Task<ServiceResponse<List<ShipmentType>>> GetAllAdminShipmentTypes();
        public Task<ServiceResponse<List<ShipmentType>>> AddShipmentType(ShipmentType shipmentType);
        public Task<ServiceResponse<List<ShipmentType>>> UpdateShipmentType(ShipmentType shipmentType);
        public Task<ServiceResponse<List<ShipmentType>>> DeleteShipmentType(int id);
    }
}
