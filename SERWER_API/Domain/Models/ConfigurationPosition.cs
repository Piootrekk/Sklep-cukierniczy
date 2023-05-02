using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ConfigurationPosition
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty; //Top , Bottom , Middle
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
