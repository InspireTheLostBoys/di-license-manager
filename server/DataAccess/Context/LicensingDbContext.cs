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

        public DbSet<Models.System.AdminUser> AdminUser { get; set; }
        public DbSet<Models.System.Customer> Customer { get; set; }
        public DbSet<Models.System.License> License { get; set; }
        public DbSet<Models.System.Product> Product { get; set; }
        public DbSet<Models.System.EmailSetting> EmailSettings { get; set; }
        public DbSet<Models.System.Site> Site { get; set; }
        public DbSet<Models.System.Recipient> Recipient { get; set; }

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