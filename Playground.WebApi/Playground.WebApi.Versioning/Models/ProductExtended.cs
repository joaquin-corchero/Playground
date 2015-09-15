using System;

namespace Playground.WebApi.Versioning.Models
{
   public class ProductExtended : Product
    {
        public string Description { get; protected set; }

        internal ProductExtended(int productId, string name, decimal price, string description) : base(productId, name, price)
        {
            Description = description;
        }

        public static ProductExtended Generate(int productId, string name, decimal price, string description)
        {
            return new ProductExtended(productId, name, price, description);
        }
    }
}