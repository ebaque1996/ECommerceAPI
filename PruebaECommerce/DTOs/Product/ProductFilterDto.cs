namespace PruebaECommerce.DTOs.Product
{
    public class ProductFilterDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? InStock { get; set; }
    }
}
