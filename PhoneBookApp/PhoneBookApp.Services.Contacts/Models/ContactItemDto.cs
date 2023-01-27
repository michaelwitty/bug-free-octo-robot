using System;

namespace PhoneBookApp.Services.Contacts.Models
{
    public record struct ContactItemDto
    {
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
