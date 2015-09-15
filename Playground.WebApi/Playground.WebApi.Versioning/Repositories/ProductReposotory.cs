using Playground.WebApi.Versioning.Models;
using System.Collections.Generic;
using System.Linq;

namespace Playground.WebApi.Versioning.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        List<ProductExtended> GetAllExtended();
    }

    public class ProductReposotory : IProductRepository
    {
        private static List<ProductExtended> _products;

        public ProductReposotory()
        {
            if (_products == null)
                _products = new List<ProductExtended> {
                    ProductExtended.Generate(1, "Product 1", 10.50m, "Product 1 description"),
                    ProductExtended.Generate(2, "Product 2", 10.50m, "Product 2 description"),
                    ProductExtended.Generate(3, "Product 3", 10.50m, "Product 3 description"),
                    ProductExtended.Generate(4, "Product 4", 10.50m, "Product 4 description")
                };
        }

        public List<Product> GetAll()
        {
            List<Product> _result = _products.Select(e =>
                new Product(e.ProductId, e.Name, e.Price))
            .ToList();
            return _result;
        }

        public List<ProductExtended> GetAllExtended()
        {
            return _products;
        }
    }
}