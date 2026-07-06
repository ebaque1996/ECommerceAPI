using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Domain;
using PruebaECommerce.DTOs.Product;
using PruebaECommerce.Repositories.Data;
using PruebaECommerce.Services.Product;

namespace PruebaECommerce.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductItem> GetProductByIdAsync(int productId)
        {
            var productDb = await _context.Products
                .FirstOrDefaultAsync(ci => ci.Id == productId);

            if (productDb == null)
                return null;

            return new ProductItem(
                productDb.Id,
                productDb.Code,
                productDb.Name,
                productDb.Category,
                productDb.Price,
                productDb.Stock
            );
        }

        public async Task<List<ProductItem>> GetProductsAsync(string? code, string? name, string? category, decimal? minPrice, decimal? maxPrice, bool? inStock)
        {
            //Declaramos un objeto AsQueryable para poder aplicar filtros dinámicos según los parámetros recibidos en productFilterDto
            //El query no se ejecuta hasta que se llame a ToListAsync() al final, lo que permite construir la consulta de manera flexible
            var query = _context.Products.AsQueryable();

            //Comenzamos a aplicar filtros dinámicos según los parámetros recibidos en productFilterDto
            if (!string.IsNullOrEmpty(code))
                query = query.Where(p => p.Code.Contains(code));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.Contains(category));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            if (inStock.HasValue)
            {
                if (inStock.Value)
                    query = query.Where(p => p.Stock > 0);
                else
                    query = query.Where(p => p.Stock == 0);
            }

            var products = await query
                .Select(p => new ProductItem
                (
                    p.Id,
                    p.Code,
                    p.Name,
                    p.Category,
                    p.Price,
                    p.Stock
                ))
            .ToListAsync();

            return products;
        }
    }
}
