using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalProductCatalog.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Cateogories Table
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Implants" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Consumables" }
            );

            //Barcode Table
            builder.Entity<BarcodeList>().ToTable("Barcode");
            builder.Entity<BarcodeList>().HasKey(p => p.Id);
            builder.Entity<BarcodeList>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<BarcodeList>().HasData
            (
                new BarcodeList { Id = 100, ProductId = 100 }, 
                new BarcodeList { Id = 101, ProductId = 100 },
                new BarcodeList { Id = 102, ProductId = 101 },
                new BarcodeList { Id = 103, ProductId = 101 }
            );

            //Product Table
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.ExiprationDate).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Description = "Implants1",
                    QuantityInPackage = 13,
                    UnitOfMeasurement = UnitOfMeasurement.Unity,
                    CategoryId = 100,
                    ExiprationDate = DateTime.Today.AddDays(100)
                },
                new Product
                {
                    Id = 101,
                    Description = "Implants2",
                    QuantityInPackage = 22,
                    UnitOfMeasurement = UnitOfMeasurement.Liter,
                    CategoryId = 100,
                    ExiprationDate = DateTime.Today.AddDays(200)
                },
                 new Product
                 {
                     Id = 102,
                     Description = "Consumables1",
                     QuantityInPackage = 10,
                     UnitOfMeasurement = UnitOfMeasurement.Kilogram,
                     CategoryId = 101,
                     ExiprationDate = DateTime.Today.AddDays(100)
                 },
                new Product
                {
                    Id = 103,
                    Description = "Consumables2",
                    QuantityInPackage = 29,
                    UnitOfMeasurement = UnitOfMeasurement.Box,
                    CategoryId = 101,
                    ExiprationDate = DateTime.Today.AddDays(200)
                }
            );
        }
    }
}
