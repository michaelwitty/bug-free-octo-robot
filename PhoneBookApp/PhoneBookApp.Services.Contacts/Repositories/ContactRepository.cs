using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Services.Contacts.DbContexts;
using PhoneBookApp.Services.Contacts.Entities;
using PhoneBookApp.Services.Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApp.Services.Contacts.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactDbContext _contactDbContext;

        public ContactRepository(IContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext ?? throw new ArgumentNullException(nameof(contactDbContext));
        }

        public async Task<Contact> GetContactByIdAsync(Guid contactId)
        {
            return await _contactDbContext.Contacts.Where(c => c.Id == contactId).FirstOrDefaultAsync();
        }

        public async Task AddContactAsync(Contact contact)
        {
            _contactDbContext.Contacts.Add(contact);
            await _contactDbContext.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _contactDbContext.Contacts.Update(contact);
            await _contactDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(ContactQuery query)
        {
            if (!string.IsNullOrEmpty(query.Keyword))
            {
                return await _contactDbContext.Contacts.Where(c => c.LastName.StartsWith(query.Keyword)).OrderBy(c => c.LastName).ToListAsync();
            }

            return await _contactDbContext.Contacts.OrderBy(c => c.LastName).ToListAsync();
        }

        public async Task DeleteContactAsync(Guid contactId)
        {
            var contact = await GetContactByIdAsync(contactId);
            _contactDbContext.Contacts.Remove(contact);
            await _contactDbContext.SaveChangesAsync();
        }
    }
}