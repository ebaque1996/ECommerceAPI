using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaECommerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 1 },
                    { 5, 5, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Discount", "OrderDate", "Subtotal", "Total", "UserId" },
                values: new object[,]
                {
                    { 1, 0.00m, new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc), 500.00m, 500.50m, 1 },
                    { 2, 0.00m, new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc), 405.00m, 405.00m, 2 },
                    { 3, 0.00m, new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc), 142.50m, 142.50m, 1 },
                    { 4, 0.00m, new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc), 303.00m, 303.00m, 1 },
                    { 5, 0.00m, new DateTime(2026, 7, 5, 12, 0, 0, 0, DateTimeKind.Utc), 825.00m, 825.00m, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Tecnología", "TECH-001", "Monitor 27'' 144Hz", 250.00m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Tecnología", "TECH-002", "Teclado Mecánico", 85.50m, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Tecnología", "TECH-003", "Mouse Inalámbrico", 45.00m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Tecnología", "TECH-004", "Laptop Core i7", 1200.00m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Code", "Name", "Price" },
                values: new object[] { "Tecnología", "TECH-005", "Auriculares Noise Cancelling", 150.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 6, "Oficina", "TECH-006", "Silla Ergonómica", 199.99m, 12 },
                    { 7, "Oficina", "TECH-007", "Escritorio Ajustable", 350.00m, 8 },
                    { 8, "Tecnología", "TECH-008", "Webcam 4K", 90.00m, 25 },
                    { 9, "Tecnología", "TECH-009", "Micrófono USB", 60.00m, 40 },
                    { 10, "Tecnología", "TECH-010", "Docking Station", 110.00m, 15 },
                    { 11, "Deportes", "GYM-001", "Mancuernas Ajustables 24kg", 180.00m, 20 },
                    { 12, "Suplementos", "GYM-002", "Proteína Whey 2lbs", 35.00m, 100 },
                    { 13, "Suplementos", "GYM-003", "Creatina Monohidratada", 25.00m, 80 },
                    { 14, "Suplementos", "GYM-004", "Pre-entreno", 30.00m, 60 },
                    { 15, "Deportes", "GYM-005", "Cinturón de Levantamiento", 40.00m, 30 },
                    { 16, "Deportes", "GYM-006", "Rodilleras Neopreno", 22.50m, 45 },
                    { 17, "Deportes", "GYM-007", "Zapatillas Training", 95.00m, 25 },
                    { 18, "Ropa", "GYM-008", "Camiseta Dry-Fit", 18.00m, 150 },
                    { 19, "Accesorios", "GYM-009", "Botella de Agua Acero 1L", 15.00m, 200 },
                    { 20, "Accesorios", "GYM-010", "Toalla Microfibra", 8.50m, 300 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 6, 6, 1, 1 },
                    { 7, 7, 1, 1 },
                    { 8, 8, 1, 1 },
                    { 9, 9, 2, 2 },
                    { 10, 10, 2, 2 },
                    { 11, 11, 2, 2 },
                    { 12, 12, 2, 2 },
                    { 13, 13, 2, 2 },
                    { 14, 14, 2, 2 },
                    { 15, 15, 2, 2 },
                    { 16, 16, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 50.00m },
                    { 2, 1, 2, 1, 50.00m },
                    { 3, 1, 3, 1, 50.00m },
                    { 4, 1, 4, 1, 50.00m },
                    { 5, 2, 5, 1, 50.00m },
                    { 6, 2, 6, 1, 50.00m },
                    { 7, 2, 7, 1, 50.00m },
                    { 8, 2, 8, 1, 50.00m },
                    { 9, 3, 9, 1, 50.00m },
                    { 10, 3, 10, 1, 50.00m },
                    { 11, 3, 11, 1, 50.00m },
                    { 12, 3, 12, 1, 50.00m },
                    { 13, 4, 13, 1, 50.00m },
                    { 14, 4, 14, 1, 50.00m },
                    { 15, 4, 15, 1, 50.00m },
                    { 16, 4, 16, 1, 50.00m },
                    { 17, 5, 17, 1, 50.00m },
                    { 18, 5, 18, 1, 50.00m },
                    { 19, 5, 19, 1, 50.00m },
                    { 20, 5, 20, 1, 50.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Cellphones", "INV0001", "IPhone 17", 1500.00m, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Accesories", "INV0002", "Samsung 14'inch monitor", 200.00m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Accesories", "INV0003", "Xtratech mouse", 20.00m, 25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Code", "Name", "Price", "Stock" },
                values: new object[] { "Cellphones", "INV0004", "Samsung Galaxy A25", 300.00m, 40 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Code", "Name", "Price" },
                values: new object[] { "Laptops", "INV0005", "Lenovo Legion 5 Pro Laptop", 1200.00m });
        }
    }
}
