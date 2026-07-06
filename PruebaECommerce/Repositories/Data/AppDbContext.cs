using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Domain;
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

            //Datos semilla

            //Usuarios
            modelBuilder.Entity<UserDbModel>().HasData(
                new UserDbModel { Id = 1, Email = "admin@testecommerce.com", Password = "Abc123"},
                new UserDbModel { Id = 2, Email = "usuario@testecommerce.com", Password = "Abc123"}
            );

            //Productos
            modelBuilder.Entity<ProductDbModel>().HasData(
                new ProductDbModel { Id = 1, Code = "TECH-001", Name = "Monitor 27'' 144Hz", Category = "Tecnología", Price = 250.00m, Stock = 15 },
                new ProductDbModel { Id = 2, Code = "TECH-002", Name = "Teclado Mecánico", Category = "Tecnología", Price = 85.50m, Stock = 30 },
                new ProductDbModel { Id = 3, Code = "TECH-003", Name = "Mouse Inalámbrico", Category = "Tecnología", Price = 45.00m, Stock = 50 },
                new ProductDbModel { Id = 4, Code = "TECH-004", Name = "Laptop Core i7", Category = "Tecnología", Price = 1200.00m, Stock = 10 },
                new ProductDbModel { Id = 5, Code = "TECH-005", Name = "Auriculares Noise Cancelling", Category = "Tecnología", Price = 150.00m, Stock = 20 },
                new ProductDbModel { Id = 6, Code = "TECH-006", Name = "Silla Ergonómica", Category = "Oficina", Price = 199.99m, Stock = 12 },
                new ProductDbModel { Id = 7, Code = "TECH-007", Name = "Escritorio Ajustable", Category = "Oficina", Price = 350.00m, Stock = 8 },
                new ProductDbModel { Id = 8, Code = "TECH-008", Name = "Webcam 4K", Category = "Tecnología", Price = 90.00m, Stock = 25 },
                new ProductDbModel { Id = 9, Code = "TECH-009", Name = "Micrófono USB", Category = "Tecnología", Price = 60.00m, Stock = 40 },
                new ProductDbModel { Id = 10, Code = "TECH-010", Name = "Docking Station", Category = "Tecnología", Price = 110.00m, Stock = 15 },
                new ProductDbModel { Id = 11, Code = "GYM-001", Name = "Mancuernas Ajustables 24kg", Category = "Deportes", Price = 180.00m, Stock = 20 },
                new ProductDbModel { Id = 12, Code = "GYM-002", Name = "Proteína Whey 2lbs", Category = "Suplementos", Price = 35.00m, Stock = 100 },
                new ProductDbModel { Id = 13, Code = "GYM-003", Name = "Creatina Monohidratada", Category = "Suplementos", Price = 25.00m, Stock = 80 },
                new ProductDbModel { Id = 14, Code = "GYM-004", Name = "Pre-entreno", Category = "Suplementos", Price = 30.00m, Stock = 60 },
                new ProductDbModel { Id = 15, Code = "GYM-005", Name = "Cinturón de Levantamiento", Category = "Deportes", Price = 40.00m, Stock = 30 },
                new ProductDbModel { Id = 16, Code = "GYM-006", Name = "Rodilleras Neopreno", Category = "Deportes", Price = 22.50m, Stock = 45 },
                new ProductDbModel { Id = 17, Code = "GYM-007", Name = "Zapatillas Training", Category = "Deportes", Price = 95.00m, Stock = 25 },
                new ProductDbModel { Id = 18, Code = "GYM-008", Name = "Camiseta Dry-Fit", Category = "Ropa", Price = 18.00m, Stock = 150 },
                new ProductDbModel { Id = 19, Code = "GYM-009", Name = "Botella de Agua Acero 1L", Category = "Accesorios", Price = 15.00m, Stock = 200 },
                new ProductDbModel { Id = 20, Code = "GYM-010", Name = "Toalla Microfibra", Category = "Accesorios", Price = 8.50m, Stock = 300 }
            );

            //Cart Items
            var cartItems = new List<CartItemDbModel>();
            int cartItemId = 1;
            // Usuario 1
            for (int p = 1; p <= 8; p++) cartItems.Add(new CartItemDbModel { Id = cartItemId++, UserId = 1, ProductId = p, Quantity = 1 });
            // Usuario 2
            for (int p = 9; p <= 16; p++) cartItems.Add(new CartItemDbModel { Id = cartItemId++, UserId = 2, ProductId = p, Quantity = 2 });

            modelBuilder.Entity<CartItemDbModel>().HasData(cartItems);

            //Ordenes
            var staticDate = new DateTime(2026, 7, 5, 12, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<OrderDbModel>().HasData(
                new OrderDbModel { Id = 1, UserId = 1, OrderDate = staticDate, Subtotal = 500.00m, Discount = 0.00m, Total = 500.50m },
                new OrderDbModel { Id = 2, UserId = 2, OrderDate = staticDate, Subtotal = 405.00m, Discount = 0.00m, Total = 405.00m },
                new OrderDbModel { Id = 3, UserId = 1, OrderDate = staticDate, Subtotal = 142.50m, Discount = 0.00m, Total = 142.50m },
                new OrderDbModel { Id = 4, UserId = 1, OrderDate = staticDate, Subtotal = 303.00m, Discount = 0.00m, Total = 303.00m },
                new OrderDbModel { Id = 5, UserId = 2, OrderDate = staticDate, Subtotal = 825.00m, Discount = 0.00m, Total = 825.00m }
            );

            //Detalle de ordenes
            var orderDetails = new List<OrderDetailDbModel>();
            int orderDetailId = 1;
            int productIdCounter = 1;

            for (int orderId = 1; orderId <= 5; orderId++)
            {
                for (int j = 0; j < 4; j++)
                {
                    orderDetails.Add(new OrderDetailDbModel
                    {
                        Id = orderDetailId++,
                        OrderId = orderId,
                        ProductId = productIdCounter,
                        Quantity = 1,
                        UnitPrice = 50.00m // Monto de ejemplo para evitar buscar el precio exacto en memoria
                    });

                    productIdCounter++;
                    if (productIdCounter > 20) productIdCounter = 1; // Reiniciar si llega a 20
                }
            }
            modelBuilder.Entity<OrderDetailDbModel>().HasData(orderDetails);
        }

    }
}
