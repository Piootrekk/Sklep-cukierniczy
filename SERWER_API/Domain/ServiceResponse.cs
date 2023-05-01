using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServiceResponse<T>
    {
        public T? Value { get; set; }
        public bool Success { get; set; }
        public string ReturnMesage { get; set; } = String.Empty;
    }
}
