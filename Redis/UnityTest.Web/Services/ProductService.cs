using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityTest.Web.Entities;
using UnityTest.Web.Repositories;

namespace UnityTest.Web.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        void AddProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return this._productRepository.GetProducts();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product");

            this._productRepository.AddProduct(product);
        }
    }
}