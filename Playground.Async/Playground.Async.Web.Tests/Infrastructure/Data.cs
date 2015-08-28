using Playground.Async.Web.Infrastructure.Entities;
using System.Collections.Generic;

namespace Playground.Async.Web.Tests.Infrastructure
{
    internal static class Data
    {
        private static List<Product> _products;
        internal static List<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new List<Product> {
                        Product.Generate("First", 20, "First description"),
                        Product.Generate("Second", 30, "Second description"),
                        Product.Generate("Third", 40, "Third description")
                    };
                }

                return _products;
            }
        }
    }
}
