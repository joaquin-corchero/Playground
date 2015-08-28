using System.ComponentModel.DataAnnotations;

namespace Playground.Async.Web.Infrastructure.Entities
{
    public class Product
    {
        public int ProductId { get; protected set; }

        [Required]
        public string Name { get; protected set; }

        [Required]
        public decimal Price { get; protected set; }

        [Required]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "The description has the wrong lenght 5 - 2050")]
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