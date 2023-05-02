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
        public ShipmentType ShipmentType { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public bool IsPayed { get; set; }
        public DateTime OrderCreated { get; set; }
        public bool IsAccepted { get; set; } = false;
        public DateTime OrderAccepted { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime OrderCompleted { get; set; }
        public bool IsCanceled { get; set; } 
        public DateTime OrderCanceled { get; set; }

    }
}
