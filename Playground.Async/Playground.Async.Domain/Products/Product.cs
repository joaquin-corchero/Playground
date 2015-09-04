using System;
using System.Runtime.CompilerServices;

//To make protected internal properties available to the tests, so tests can set the Id
[assembly: InternalsVisibleTo("Playground.Async.Tests")]
namespace Playground.Async.Domain.Products
{
    public class Product
    {
        public int ProductId { get; protected internal set; }

        public DateTime CreationDate { get; protected set; }

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

        public void Set(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
            CreationDate = DateTime.Now;
        }
    }
}
