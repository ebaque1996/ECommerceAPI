using PruebaECommerce.Domain;

namespace PruebaECommerce.Services.Product
{
    public interface IProductRepository
    {
        Task<ProductItem> GetProductByIdAsync(int productId);
        Task<List<ProductItem>> GetProductsAsync(string? code, string? name, string? category, decimal? minPrice, decimal? maxPrice, bool? inStock);
    }
}
