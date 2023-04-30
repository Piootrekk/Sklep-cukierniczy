using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Localisation? Localisation { get; set; }
        public Role? Role { get; set; } 
        public string PhoneNumber { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public bool IsActive { get; set; }



    }
}
