using PruebaECommerce.Common.Results;
using PruebaECommerce.DTOs.Product;

namespace PruebaECommerce.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductItemResponseDto>> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            //Si no se encuentra el producto, devolvemos un error 404
            if (product == null)
                return new Result<ProductItemResponseDto> { Success = false, Message = "Product not found.", StatusCode = 404 };

            return new Result<ProductItemResponseDto> { 
                Success = true, 
                StatusCode = 200, 
                Data = new ProductItemResponseDto { 
                    Product = product 
                } 
            };
        }

        public async Task<Result<ProductResponseDto>> GetProductsAsync(ProductFilterDto productFilterDto)
        {
            var products = await _productRepository.GetProductsAsync(productFilterDto.Code, productFilterDto.Name, productFilterDto.Category, productFilterDto.MinPrice, productFilterDto.MaxPrice, productFilterDto.InStock);

            //Si no se encuentra al menos un producto en base a los criterios enviados, devolvemos un error 404
            if (products == null || products.Count == 0)
                return new Result<ProductResponseDto> { Success = false, Message = "Products not found.", StatusCode = 404 };

            return new Result<ProductResponseDto> { 
                Success = true, 
                StatusCode = 200, 
                Data = new ProductResponseDto { 
                    Items = products
                }  
            };
        }
    }
}
