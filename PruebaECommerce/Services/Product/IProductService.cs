using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Product;

namespace PruebaECommerce.Services.Product
{
    public interface IProductService
    {
        Task<Result<ProductItemResponseDto>> GetProductByIdAsync(int productId);
        Task<Result<ProductResponseDto>> GetProductsAsync(ProductFilterDto productFilterDto);
    }
}
