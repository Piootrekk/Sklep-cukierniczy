using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public ShipmentType? ShipmentType { get; set; }
        public int ShipmentTypeId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public List<OrderProductItem>? OrderProductItems { get; set; } 
        public List<CustomCakeProductItem>? CustomCakeProductItem { get; set; } 
        public bool IsPayed { get; set; }=false;
        public DateTime OrderCreated { get; set; }
        public bool IsAccepted { get; set; } = false;
        public DateTime? OrderAccepted { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? OrderCompleted { get; set; }
        public bool IsCanceled { get; set; } = false;
        public DateTime? OrderCanceled { get; set; }


    }
}
