using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Services.Contacts.Models
{
    public record struct ContactEditDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
