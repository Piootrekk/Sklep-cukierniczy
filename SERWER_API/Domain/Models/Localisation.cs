using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Localisation
    {
        public int Id { get; set; }
        public string StreetName { get; set; } = String.Empty;
        public string CityName { get; set; } = String.Empty;
        public string HouseNumber { get; set; } = String.Empty;
        public string PostalCode { get; set; } = String.Empty;
    }
}
