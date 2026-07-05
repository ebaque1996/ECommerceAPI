using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Product;

namespace PruebaECommerce.Services.Product
{
    public interface IProductService
    {
        Task<Result<ProductResponseDto>> GetProductByIdAsync(int productId);
        Task<Result<List<ProductResponseDto>>> GetProductsAsync(ProductFilterDto productFilterDto);
    }
}
