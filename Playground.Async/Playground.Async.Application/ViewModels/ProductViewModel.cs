using Playground.Async.Domain.Products;
using System;
using System.Collections.Generic;

namespace Playground.Async.Application.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductViewModel() { }

        public static List<ProductViewModel> GetFromProducts(List<Product> products)
        {
            var result = new List<ProductViewModel>();
            products.ForEach(p => result.Add(new ProductViewModel(p)));

            return result;
        }

        private ProductViewModel(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
        }

    }
}
