using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CustomCake
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal PriceBrutto { get; set; }
        public string IngredientList { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
