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
        public Task<ServiceResponse<bool>> CreateOrder(OrderDTO orderDTO);
        public Task<ServiceResponse<List<OrderDTO>>> GetAllOrders();
        public Task<ServiceResponse<List<OrderDTO>>> GetAllUserOrders(int UserID);
        public Task<ServiceResponse<List<Order>>> GetOrderByID(int id);
        public Task<ServiceResponse<bool>> ConfirmPayment(int OrderID);
        public Task<ServiceResponse<bool>> AcceptOrder(int OrderID);
        public Task<ServiceResponse<bool>> CencleOrder(int OrderID);
        public Task<ServiceResponse<bool>> CompleteOrder(int OrderID);
    }
}
