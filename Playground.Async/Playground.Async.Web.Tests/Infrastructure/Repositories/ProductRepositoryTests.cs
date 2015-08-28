using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using Playground.Async.Web.Infrastructure.Entities;
using Playground.Async.Web.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Async.Web.Tests.Infrastructure.Repositories
{
    public class when_working_with_the_product_repository : RepositoryBase
    {
        protected ProductRepository _productRepository;

        protected override void Establish_context()
        {
            base.Establish_context();

            this._productRepository = new ProductRepository(_dbContext.Object);
        }
    }

    [TestClass]
    public class and_getting_all_the_products : when_working_with_the_product_repository
    {
        private Task<List<Product>> _actual;

        protected override void Establish_context()
        {
            base.Establish_context();
        }

        private void Execute()
        {
            this._actual = _productRepository.GetAll();
        }

        [TestMethod]
        public void then_the_products_get_returned()
        {
            var expected = Data.Products;
            Execute();

            _actual.Result.ForEach(r => expected.ShouldContain(r));
            _actual.Result.Count.ShouldEqual(expected.Count);
        }
    }

    [TestClass]
    public class and_filtering_products_by_name : when_working_with_the_product_repository
    {
        private Task<List<Product>> _actual;
        private Product _product;

        protected override void Establish_context()
        {
            base.Establish_context();
            _product = Data.Products.FirstOrDefault();
        }

        private void Execute(string productName)
        {
            this._actual = _productRepository.FilterByName(productName);
        }

        [TestMethod]
        public void then_the_product_can_be_returned()
        {
            Execute(_product.Name);

            _actual.Result.ShouldContain(_product);
            _actual.Result.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void then_if_the_product_is_not_found_empty_list_is_returned()
        {
            Execute(Guid.NewGuid().ToString());

            _actual.Result.Count.ShouldEqual(0);
        }
    }
}
