using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class OrderDTO
    {
        public decimal Price { get; set; }
        public int ShipmentTypeId { get; set; }
        public int UserId { get; set; }
        public List<OrderProductItemDTO>? OrderProductItemsDTO { get; set; }
        public List<CustomCakeProductItemDTO>? CustomCakeProductItemsDTO { get; set; }
        public bool IsPayed { get; set; }

    }
}
