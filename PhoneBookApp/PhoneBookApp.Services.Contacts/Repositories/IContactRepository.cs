using PhoneBookApp.Services.Contacts.Entities;
using PhoneBookApp.Services.Contacts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookApp.Services.Contacts.Repositories
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
        Task DeleteContactAsync(Guid contactId);
        Task<Contact> GetContactByIdAsync(Guid contactId);
        Task<IEnumerable<Contact>> GetContactsAsync(ContactQuery query);
        Task UpdateContactAsync(Contact contact);
    }
}