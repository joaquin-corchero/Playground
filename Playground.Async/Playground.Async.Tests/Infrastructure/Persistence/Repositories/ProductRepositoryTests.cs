using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Domain.Products;
using Playground.Async.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Async.Tests.Infrastructure.Persistence.Repositories
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
        private Task<List<Domain.Products.Product>> _actual;

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
        private Task<List<Domain.Products.Product>> _actual;
        private Domain.Products.Product _product;

        protected override void Establish_context()
        {
            base.Establish_context();
            _product = Data.Products.LastOrDefault();
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

    [TestClass]
    public class and_adding_a_new_product : when_working_with_the_product_repository
    {
        private Domain.Products.Product _product;
        private Task<Domain.Products.Product> _result;

        private void Execute()
        {
            _result = _productRepository.Add(_product);
        }

        [TestMethod]
        public void then_the_product_can_be_added()
        {
            _product = Product.Generate("Name", 25.25m, "This is a very long description");
            Execute();

            _products.Verify(p => p.Add(_product), Times.Once);
        }
    }
}
