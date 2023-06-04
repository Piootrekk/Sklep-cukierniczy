using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CustomCakeProductItem
    {
        public int Id { get; set; }
        public CustomCake CustomCake { get; set; }
        public int CustomCakeId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
