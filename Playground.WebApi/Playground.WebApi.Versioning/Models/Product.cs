namespace Playground.WebApi.Versioning.Models
{
    public class Product
    {
        public int ProductId { get; protected set; }

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        internal Product(int productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }
}