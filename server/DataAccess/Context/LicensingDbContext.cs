using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class LicensingDbContext : DbContext
    {
        public LicensingDbContext(DbContextOptions<LicensingDbContext> options)
            : base(options)
        {

        }

<<<<<<< HEAD
        public DbSet<Models.System.AdminUser>AdminUsers { get; set; }
        public DbSet<Models.System.Customer>Customers { get; set; }
        public DbSet<Models.System.License>Licenses { get; set; }
        public DbSet<Models.System.Product>Products { get; set; }
        public DbSet<Models.System.EmailSetting>EmailSettings { get; set; }
        public DbSet<Models.System.Site>Sites { get; set; }
        public DbSet<Models.System.CustomerRecipient>CustomerRecipients { get; set; }
        
=======
        public DbSet<Models.System.AdminUser> AdminUser { get; set; }
        public DbSet<Models.System.Customer> Customer { get; set; }
        public DbSet<Models.System.License> License { get; set; }
        public DbSet<Models.System.Product> Product { get; set; }
        public DbSet<Models.System.EmailSettings> EmailSettings { get; set; }
        public DbSet<Models.System.Site> Site { get; set; }
        public DbSet<Models.System.Recipient> Recipient { get; set; }
>>>>>>> 1c41dc8900f93592ec367fd8b599d887e321c664

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Models.System.AdminUser>()
             .HasData( new Models.System.AdminUser { 
                  ID = 1,
                  FirstName = "Admin User",
                  LastName = "Admin User", 
                  Active = true, 
                  EmailAddress = "lana@devinspire.com", 
                  Password = "Pass@123" 
             });
        }

    }
}