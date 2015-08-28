using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityTest.Web.Entities;

namespace UnityTest.Web.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        void AddProduct(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;
        public static List<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new List<Product>();

                return _products;
            }
            set { _products = value; }
        }

        public List<Product> GetProducts()
        {
            return ProductRepository.Products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }
}