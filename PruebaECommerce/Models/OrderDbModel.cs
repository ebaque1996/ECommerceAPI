namespace PruebaECommerce.Models
{
    public class OrderDbModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }


        public UserDbModel User { get; set; }
        public ICollection<OrderDetailDbModel> OrderDetails { get; set; } = new List<OrderDetailDbModel>();

    }
}
