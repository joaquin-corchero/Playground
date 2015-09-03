namespace Playground.Async.Domain.Products
{
    public class Product : AggregateRoot
    {

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        public string Description { get; protected set; }

        protected Product() { }

        private Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public static Product Generate(string name, decimal price, string description)
        {
            return new Product(name, price, description);
        }
    }
}
