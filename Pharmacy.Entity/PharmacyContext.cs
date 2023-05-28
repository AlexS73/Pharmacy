using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<CharacteristicType> CharacteristicTypes { get; set; }

        public PharmacyContext() : base()
        {
           
        }
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var departments = new Department[]
            //{
            //        new Department{Id = 1, Name = "Управление", Address = "Ул. Мира 1"},
            //        new Department{Id = 2, Name = "ООО Аптека 1", Address = "Ул. Ершова 2"},
            //        new Department{Id = 3, Name = "ООО Аптека 2", Address = "Ул. Мира 5"}
            //};

            //modelBuilder.Entity<Department>().HasData(departments);

            //var warehouses = new Warehouse[]
            //{
            //    new Warehouse{Id = 1, Address = "Ул. Мира 1", DepartmentId = 1, Name = "Управление"},
            //    new Warehouse{Id = 2, Address = "Ул. Ершова 2", DepartmentId = 2, Name = "ООО Аптека 1"},
            //    new Warehouse{Id = 3, Address = "Ул. Мира 5", DepartmentId = 3, Name = "ООО Аптека 2"}
            //};

            //modelBuilder.Entity<Warehouse>().HasData(warehouses);

            //modelBuilder.Entity<CharacteristicType>().HasData(
            //new CharacteristicType[]
            //{
            //    new CharacteristicType() { Id = 1, Name = "Категория" },
            //    new CharacteristicType() { Id = 2, Name = "Срок годности"}
            //});

            //var characteristics = new Characteristic[]
            //{
            //    new Characteristic() { Id = 1, TypeId = 1, Value = "Перевязочный материал"},
            //    new Characteristic() { Id = 2, TypeId = 1, Value = "Лекарственные средства"},
            //    new Characteristic() { Id = 3, TypeId = 1, Value = "Спирт"},
            //    new Characteristic() { Id = 4, TypeId = 1, Value = "Препараты для нервной системы"},
            //    new Characteristic() { Id = 5, TypeId = 1, Value = "Аллергия"},
            //    new Characteristic() { Id = 6, TypeId = 1, Value = "Средства для тела"},
            //    new Characteristic() { Id = 7, TypeId = 1, Value = "Витамины"},
            //    new Characteristic() { Id = 8, TypeId = 1, Value = "Заживление ран"},
            //};
            //modelBuilder.Entity<Characteristic>().HasData(characteristics);

            //var products = new Product[]
            //{
            //    new Product{Id = 1, Name = "Бинт", Article = "A1", Description = "Перевязочный материал", Characteristics = new Characteristic[]{ characteristics[0] } },
            //    new Product{Id = 2, Name = "Йодомарин", Article = "А2", Description = "Йод", Characteristics = new Characteristic[]{ characteristics[1] }},
            //    new Product{Id = 3, Name = "Спирт", Article = "А3", Description = "Спирт", Characteristics = new Characteristic[]{ characteristics[2] }},
            //    new Product{Id = 4, Name = "Парацетамол", Article = "А4", Description = "Парацетамол",Characteristics = new Characteristic[]{ characteristics[3] }},
            //    new Product{Id = 5, Name = "Супрастин", Article = "А5", Characteristics = new Characteristic[]{ characteristics[4] }, Description = "Крапивница, сывороточная болезнь, сезонный и круглогодичный аллергический ринит, аллергический конъюнктивит, контактный дерматит, кожный зуд, острая и хроническая экзема, атопический дерматит, пищевая и лекарственная аллергия, аллергические реакции на укусы насекомых."}
            //    new Product{Id = 6, Name = "Крем для ног", Article = "Б1",Characteristics = new Characteristic[]{ characteristics[5] }, Description = "Рекомендован для интенсивного смягчения очень сухой, огрубевшей и потрескавшейся кожи стоп; эффективного и безопасного устранения сухих мозолей и натоптышей; предотвращения грибковой микрофлоры и появления неприятного запаха."},
            //    new Product{Id = 7, Name = "Витамин с", Article = "Б2",Characteristics = new Characteristic[]{ characteristics[6] }, Description = "Рекомендуется в качестве биологически активной добавки к пище - дополнительного источника витаминов С и В2."},
            //    new Product{Id = 8, Name = "Акридерм", Article = "Б3",Characteristics = new Characteristic[]{ characteristics[7] }, Description = "Заболевания кожи, поддающиеся глюкокортикостероидной терапии:"},
            //    new Product{Id = 4, Name = "Адвантан", Article = "В1",Characteristics = new Characteristic[]{ characteristics[7] }, Description = "Воспалительные заболевания кожи, чувствительные к терапии топическими глюкокортикостероидами"},
            //};
            //modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Characteristic>().Property(_ => _.Value).IsRequired();

            modelBuilder.Entity<Sale>().ToTable("Sales");   
            modelBuilder.Entity<Entrance>().ToTable("Entrances");
            modelBuilder.Entity<Warehouse>().HasMany(_ => _.Operations).WithOne(_ => _.Warehouse).HasForeignKey(_ => _.WarehouseId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
