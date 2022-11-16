using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Entity
{
    public class PharmacyContext: IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WarehouseOperation> WarehouseOperations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOperation> ProductOperations { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<SaleProduct> SaleProduct { get; set; }
        public DbSet<EntranceProduct> EntranceProduct { get; set; }

        public PharmacyContext() : base()
        {}
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=alexhomepc;Database=PharmacyTest;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Entrance>().ToTable("Entrances");
            modelBuilder.Entity<Product>().HasOne(_ => _.Warehouse).WithOne(_ => _.Product);

            base.OnModelCreating(modelBuilder);
        }
    }
}
