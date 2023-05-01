using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UserRegisterDTO
    {
        [Required, StringLength(100, MinimumLength = 3)]
        public string Username { get; set; } = String.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = String.Empty;
        [Compare("Password", ErrorMessage = "The passwords must be identical")]
        public string ConfirmPassword { get; set; } = String.Empty;
        [Required, Phone]
        public string PhoneNumber { get; set; } = String.Empty;
        [Required]
        public string StreetName { get; set; } = String.Empty;
        [Required]
        public string CityName { get; set; } = String.Empty;
        [Required]
        public string HouseNumber { get; set; } = String.Empty;
        [Required]
        public string PostalCode { get; set; } = String.Empty;
        [Required]
        public string FirstName { get; set; } = String.Empty;
        [Required]
        public string LastName { get; set; } = String.Empty;
        public Role? Role { get; set; }
    }
}
