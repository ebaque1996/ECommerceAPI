using PruebaECommerce.Domain;

namespace PruebaECommerce.DTOs.Product
{
    public class ProductResponseDto
    {
        public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
