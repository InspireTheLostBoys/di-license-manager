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

        public DbSet<Models.System.AdminUser>AdminUsers { get; set; }
        public DbSet<Models.System.Customer>Customers { get; set; }
        public DbSet<Models.System.License>Licenses { get; set; }
        public DbSet<Models.System.Product>Products { get; set; }
        public DbSet<Models.System.EmailSetting>EmailSettings { get; set; }
        public DbSet<Models.System.Site>Sites { get; set; }
        public DbSet<Models.System.CustomerRecipient>CustomerRecipients { get; set; }
        public DbSet<Models.System.Car> Cars { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Models.System.AdminUser>()
        //     .HasData(
        //      new Models.System.AdminUser { ID = 1, FirstName = "Admin User", LastName = "Admin User", Active = true, EmailAddress = "admin@devinspire.co.za", Password = "Pass@123" });

        //    modelBuilder.Entity<Models.System.License>()
        //     .HasData(
        //      new Models.System.License { ID = 1, CustomerId = 1, SiteId = 2, ProductId = 3, CustomerName = "CustomerName" });
        //}

    }
}