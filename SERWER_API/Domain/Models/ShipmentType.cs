using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ShipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceBrutto { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
