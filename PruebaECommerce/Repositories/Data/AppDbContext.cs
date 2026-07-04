using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Models;

namespace PruebaECommerce.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18,2);
            modelBuilder.Entity<Order>().Property(p => p.Subtotal).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(p => p.Discount).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(p => p.Total).HasPrecision(18, 2);
            modelBuilder.Entity<OrderDetail>().Property(p => p.UnitPrice).HasPrecision(18, 2);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@testecommerce.com", Password = "Abc123"},
                new User { Id = 2, Email = "usuario@testecommerce.com", Password = "Abc123"}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Code = "INV0001", Name = "IPhone 17", Category = "Cellphones", Price = 1500.00m, Stock = 30 },
                new Product { Id = 2, Code = "INV0002", Name = "Samsung 14'inch monitor", Category = "Accesories", Price = 200.00m, Stock = 50 },
                new Product { Id = 3, Code = "INV0003", Name = "Xtratech mouse", Category = "Accesories", Price = 20.00m, Stock = 25 },
                new Product { Id = 4, Code = "INV0004", Name = "Samsung Galaxy A25", Category = "Cellphones", Price = 300.00m, Stock = 40 },
                new Product { Id = 5, Code = "INV0005", Name = "Lenovo Legion 5 Pro Laptop", Category = "Laptops", Price = 1200.00m, Stock = 20 }
            );
        }

    }
}
