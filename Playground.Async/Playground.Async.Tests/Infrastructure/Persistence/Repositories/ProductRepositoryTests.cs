﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private Product _product;
        private Task<Product> _result;

        private void Execute()
        {
            _result = _productRepository.Add(_product);
        }

        [TestMethod]
        public void then_the_product_can_be_added()
        {
            _product = Product.Generate("Name", 25.25m, "This is a very long description");
            Execute();

            _productsDbSet.Verify(p => p.Add(_product), Times.Once);
        }
    }

    [TestClass]
    public class and_updating_an_existing_product : when_working_with_the_product_repository
    {
        private Product _product;
        private Task<Product> _result;
        private Guid _productId;

        protected override void Establish_context()
        {
            base.Establish_context();

            _product = Data.Products.FirstOrDefault();
            _productId = _product.Id;
            _productsDbSet.Setup(s => s.FindAsync(_productId)).Returns(Task.FromResult(_product));
        }

        private void Execute()
        {
            _result = _productRepository.Update(_product, _productId);
        }

        [TestMethod]
        public void then_if_the_product_exists_it_gets_updated()
        {
            _product.Set(string.Format("New Name {0}", Guid.NewGuid()), 500m, "This is the new product description");
            Execute();

            _productsDbSet.Verify(p => p.FindAsync(_productId), Times.Once);
            _dbContext.Verify(c => c.Entry(It.Is<Product>(p => p.Id == _productId)), Times.Once);
        }

        [TestMethod]
        public async Task then_if_no_product_is_passed_execption_is_thrown()
        {
            _product = null;
            string expected = string.Format("No Item provided to update");
            VerifyException(expected, await ExecuteForException());
            _productsDbSet.Verify(p => p.FindAsync(_productId), Times.Never);
        }
        private void VerifyException(string expected, string actual)
        {
            actual.ShouldContain(expected);
            _dbContext.Verify(c => c.Entry(It.Is<Product>(p => p.Id == _productId)), Times.Never);
        }

        private async Task<string> ExecuteForException()
        {
            var result = string.Empty;
            try
            {
                await _productRepository.Update(_product, _productId);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        [TestMethod]
        public async Task then_if_no_productId_is_default_null_is_returned()
        {
            _productId = new Guid();
            string expected = string.Format("Invalid Item Key passed {0}", _productId);
            VerifyException(expected, await ExecuteForException());
            _productsDbSet.Verify(p => p.FindAsync(_productId), Times.Never);
        }

        [TestMethod]
        public async Task then_if_no_product_is_found_exception_is_found()
        {
            Product nullProduct = null;
            _productsDbSet.Setup(s => s.FindAsync(_productId)).Returns(Task.FromResult(nullProduct));

            string expected = string.Format("Couldn't find the Item with Id {0}", _productId);
            VerifyException(expected, await ExecuteForException());
            _productsDbSet.Verify(p => p.FindAsync(_productId), Times.Once);
        }
    }
}
