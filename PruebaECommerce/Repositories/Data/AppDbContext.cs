using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Models;

namespace PruebaECommerce.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<ProductDbModel> Products { get; set; }
        public DbSet<CartItemDbModel> CartItems { get; set; }
        public DbSet<OrderDbModel> Orders { get; set; }
        public DbSet<OrderDetailDbModel> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDbModel>().Property(p => p.Price).HasPrecision(18,2);
            modelBuilder.Entity<OrderDbModel>().Property(p => p.Subtotal).HasPrecision(18, 2);
            modelBuilder.Entity<OrderDbModel>().Property(p => p.Discount).HasPrecision(18, 2);
            modelBuilder.Entity<OrderDbModel>().Property(p => p.Total).HasPrecision(18, 2);
            modelBuilder.Entity<OrderDetailDbModel>().Property(p => p.UnitPrice).HasPrecision(18, 2);

            modelBuilder.Entity<UserDbModel>().HasData(
                new UserDbModel { Id = 1, Email = "admin@testecommerce.com", Password = "Abc123"},
                new UserDbModel { Id = 2, Email = "usuario@testecommerce.com", Password = "Abc123"}
            );

            modelBuilder.Entity<ProductDbModel>().HasData(
                new ProductDbModel { Id = 1, Code = "INV0001", Name = "IPhone 17", Category = "Cellphones", Price = 1500.00m, Stock = 30 },
                new ProductDbModel { Id = 2, Code = "INV0002", Name = "Samsung 14'inch monitor", Category = "Accesories", Price = 200.00m, Stock = 50 },
                new ProductDbModel { Id = 3, Code = "INV0003", Name = "Xtratech mouse", Category = "Accesories", Price = 20.00m, Stock = 25 },
                new ProductDbModel { Id = 4, Code = "INV0004", Name = "Samsung Galaxy A25", Category = "Cellphones", Price = 300.00m, Stock = 40 },
                new ProductDbModel { Id = 5, Code = "INV0005", Name = "Lenovo Legion 5 Pro Laptop", Category = "Laptops", Price = 1200.00m, Stock = 20 }
            );
        }

    }
}
