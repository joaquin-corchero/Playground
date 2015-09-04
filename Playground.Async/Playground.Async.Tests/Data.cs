using Playground.Async.Domain.Products;
using System.Collections.Generic;

namespace Playground.Async.Tests
{
    internal static class Data
    {
        private static List<Product> _products;
        internal static List<Product> Products
        {
            get
            {
                if (_products == null)
                    GenerateProducts(5);

                return _products;
            }
        }

        private static void GenerateProducts(int numberOfProducts)
        {
            _products = new List<Product>();
            for (var i = 0; i < numberOfProducts; i++)
            {
                var product = Product.Generate(string.Format("Product {0}", i + 1), i * 15.5m, string.Format("Description {0}", i + 1));
                product.ProductId = i + 1;

                _products.Add(product);
            }
        }
    }
}