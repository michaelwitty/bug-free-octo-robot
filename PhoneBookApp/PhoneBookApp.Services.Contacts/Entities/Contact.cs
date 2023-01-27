using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Services.Contacts.Entities
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}