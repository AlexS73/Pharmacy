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
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<SaleProduct> SaleProduct { get; set; }
        public DbSet<EntranceProduct> EntranceProduct { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }

        public PharmacyContext() : base()
        {
           
        }
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=alexhomepc;Database=PharmacyTest;User ID=sa;Password=12345678;");
            //optionsBuilder.UseInterBase(@"Server=localhost;Database=PharmacyTest;user id=sysdba;password=masterkey");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department[] { 
                    new Department{Id = 1, Name = "Управление"}
                });

            modelBuilder.Entity<Sale>().ToTable("Sales");   
            modelBuilder.Entity<Entrance>().ToTable("Entrances");
            modelBuilder.Entity<Warehouse>().HasMany(_ => _.Operations).WithOne(_ => _.Warehouse).HasForeignKey(_ => _.WarehouseId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
