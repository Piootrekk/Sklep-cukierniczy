using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.IServices
{
    public interface IOrderService
    {
        public Task<ServiceResponse<bool>> CreateOrder(List<CustomCakeProductItem> customcakelist , List<OrderProductItem> orderProducts);
        public Task<ServiceResponse<List<Order>>> GetAllOrders();
        public Task<ServiceResponse<List<Order>>> GetAllUserOrders(int UserID);
        public Task<ServiceResponse<bool>> ConfirmPayment(int OrderID);
        public Task<ServiceResponse<bool>> AcceptOrder(int OrderID);
        public Task<ServiceResponse<bool>> CencleOrder(int OrderID);
        public Task<ServiceResponse<bool>> CompleteOrder(int OrderID);
    }
}
