namespace PruebaECommerce.Domain
{
    public class CartItem
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int ProductId { get; private set; }        
        public string? ProductName { get; private set; }
        public string? ProductCode { get; private set; }
        public decimal? UnitPrice { get; private set; }
        public int Quantity { get; set; }

        public CartItem(int id, int userId, int productId, string? productName, string? productCode, decimal? unitPrice, int quantity)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            ProductName = productName;
            ProductCode = productCode;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
