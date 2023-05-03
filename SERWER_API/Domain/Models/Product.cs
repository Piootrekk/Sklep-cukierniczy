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
        public List<OrderProductItem> OrderProductItems { get; set; }
        public List<CustomCake>? CustomCakes { get; set; }
        public ConfigurationPosition? Position { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceBrutto { get; set; }
        public int AmountInStock { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }
}
