using System.Collections.Generic;

namespace PhoneBookApp.Services.Contacts.Models
{
    public record ContactListResult
    {
        public List<ContactItemDto> Items { get; set; }

        public int ResultCount { get; set; }
    }
}
