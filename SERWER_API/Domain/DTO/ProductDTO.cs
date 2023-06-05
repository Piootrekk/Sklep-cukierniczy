using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool isIngredient { get; set; } = false;
        public int CategoryId { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int ConfigurationPositionId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceBrutto { get; set; }
        public int AmountInStock { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
