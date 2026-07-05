using Microsoft.EntityFrameworkCore;
using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Product;
using PruebaECommerce.Models;
using PruebaECommerce.Repositories.Data;

namespace PruebaECommerce.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<ProductResponseDto>> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Category = p.Category,
                    Price = p.Price,
                    Stock = p.Stock
                })
                .FirstOrDefaultAsync();

            if (product == null)
                return new Result<ProductResponseDto> { Success = false, Message = "Product not found.", StatusCode = 404 };

            return new Result<ProductResponseDto> { Success = true, StatusCode = 200, Data = product };
        }

        public async Task<Result<List<ProductResponseDto>>> GetProductsAsync(ProductFilterDto productFilterDto)
        {
            //Declaramos un objeto AsQueryable para poder aplicar filtros dinámicos según los parámetros recibidos en productFilterDto
            //El query no se ejecuta hasta que se llame a ToListAsync() al final, lo que permite construir la consulta de manera flexible
            var query = _context.Products.AsQueryable();

            //Comenzamos a aplicar filtros dinámicos según los parámetros recibidos en productFilterDto
            if (!string.IsNullOrEmpty(productFilterDto.Code))
                query = query.Where(p => p.Code.Contains(productFilterDto.Code));

            if (!string.IsNullOrEmpty(productFilterDto.Name))
                query = query.Where(p => p.Name.Contains(productFilterDto.Name));

            if (!string.IsNullOrEmpty(productFilterDto.Category))
                query = query.Where(p => p.Category.Contains(productFilterDto.Category));

            if (productFilterDto.MinPrice.HasValue)
                query = query.Where(p => p.Price >= productFilterDto.MinPrice.Value);

            if (productFilterDto.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= productFilterDto.MaxPrice.Value);

            if (productFilterDto.InStock.HasValue)
            {
                if (productFilterDto.InStock.Value)
                    query = query.Where(p => p.Stock > 0);
                else
                    query = query.Where(p => p.Stock == 0);
            }
            
            var products = await query
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Category = p.Category,
                    Price = p.Price,
                    Stock = p.Stock
                })
            .ToListAsync();

            if (products == null || products.Count == 0)
                return new Result<List<ProductResponseDto>> { Success = false, Message = "Products not found.", StatusCode = 404 };

            return new Result<List<ProductResponseDto>> { Success = true, StatusCode = 200, Data = products };
        }
    }
}
