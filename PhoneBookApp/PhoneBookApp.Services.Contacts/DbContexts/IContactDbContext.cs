using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBookApp.Services.Contacts.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBookApp.Services.Contacts.DbContexts
{
    public interface IContactDbContext
    {
        DbSet<Contact> Contacts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}