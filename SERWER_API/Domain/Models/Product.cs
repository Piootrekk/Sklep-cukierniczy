using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool isIngredient { get; set; } = false;
        public Category? Category { get; set; } 
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public ConfigurationPosition? Position { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceBrutto { get; set; }
        public int Amount { get; set; }

    }
}
