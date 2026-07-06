namespace PruebaECommerce.Domain
{
    public class ProductItem
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public ProductItem(int id, string code, string name, string category, decimal price, int stock)
        {
            Id = id;
            Code = code;
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }
    }
}
