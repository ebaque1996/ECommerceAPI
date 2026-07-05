namespace PruebaECommerce.Models
{
    public class OrderDetailDbModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;


        public OrderDbModel Order { get; set; } = null!;
        public ProductDbModel Product { get; set; } = null!;
    }
}
