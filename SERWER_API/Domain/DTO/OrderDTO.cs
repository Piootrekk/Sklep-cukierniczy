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
        public List<OrderProductItem>? OrderProductItems { get; set; }
        public List<CustomCakeProductItem>? CustomCakeProductItem { get; set; }

    }
}
