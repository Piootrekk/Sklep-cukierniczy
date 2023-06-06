using Application.IServices;
using Domain;
using Domain.DTO;
using Domain.Models;
using Persistence.DataContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _data;

        public OrderService(DataContext data) { _data = data; }
        public Task<ServiceResponse<bool>> AcceptOrder(int OrderID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> CencleOrder(int OrderID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> CompleteOrder(int OrderID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> ConfirmPayment(int OrderID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> CreateOrder(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Order>>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Order>>> GetAllUserOrders(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
