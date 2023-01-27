using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Services.Contacts.Entities;
using System;
using System.Linq;

namespace PhoneBookApp.Services.Contacts.DbContexts
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Eric",
                LastName = "Elliot",
                PhoneNumber = "222-555-6575"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Steve",
                LastName = "Jobs",
                PhoneNumber = "220-454-6754"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Fred",
                LastName = "Allen",
                PhoneNumber = "210-657-9886"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Steve",
                LastName = "Wozniak",
                PhoneNumber = "343-675-8786"
            });
            modelBuilder.Entity<Contact>().HasData(new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = "Bill",
                LastName = "Gates",
                PhoneNumber = "343-654-9688"
            });
        }
    }
}