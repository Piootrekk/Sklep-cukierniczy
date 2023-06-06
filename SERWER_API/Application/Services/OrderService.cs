using Application.IServices;
using Domain;
using Domain.DTO;
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

        public async Task<ServiceResponse<bool>> CreateOrder(OrderDTO orderDTO)
        {
            try
            {
                var OrderProductItemsD = new List<OrderProductItem>(); 
                var CustomCakeProductItemD = new List<CustomCakeProductItem>();

                if (orderDTO.OrderProductItemsDTO != null)
                {
                    foreach (var product in orderDTO.OrderProductItemsDTO)
                    {
                        var prod = new OrderProductItem
                        {
                            ProductId = product.ProductId,
                            //OrderId = product.OrderId,
                            Quantity = product.Quantity,
                            TotalPrice = product.TotalPrice,
                        };
                        OrderProductItemsD.Add(prod);
                    }
                }
                if (orderDTO.CustomCakeProductItemsDTO != null)
                {
                    foreach (var cake in orderDTO.CustomCakeProductItemsDTO)
                    {
                        var prod = new CustomCakeProductItem
                        {
                            CustomCakeId = cake.CustomCakeId,
                            //OrderId = cake.OrderId,
                            Quantity = cake.Quantity,
                            TotalPrice = cake.TotalPrice,
                        };
                        CustomCakeProductItemD.Add(prod);
                    }
                }

                Order order = new Order
                {
                    Price = orderDTO.Price,
                    ShipmentTypeId = orderDTO.ShipmentTypeId,
                    UserId = orderDTO.UserId,
                    OrderProductItems = OrderProductItemsD,
                    CustomCakeProductItem = CustomCakeProductItemD,
                    IsPayed = orderDTO.IsPayed,
                    OrderCreated = DateTime.Now
                };
                _data.Orders.Add(order);
                await _data.SaveChangesAsync();
                return new ServiceResponse<bool> { Value = true, Success=true, ReturnMesage = "Dodano Zamowienie" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool> { Success = false, ReturnMesage = "Blad podczas dodawania zadania : "+ex.Message };
            }

        }

        public Task<ServiceResponse<List<OrderDTO>>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<OrderDTO>>> GetAllUserOrders(int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Order>>> GetOrderByID(int id)
        {
            throw new NotImplementedException();
        }

    }
}
