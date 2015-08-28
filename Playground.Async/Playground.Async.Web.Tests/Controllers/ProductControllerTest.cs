using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Web.Controllers;
using Playground.Async.Web.Infrastructure.Entities;
using Playground.Async.Web.Infrastructure.Repositories;
using Playground.Async.Web.Tests.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Playground.Async.Web.Tests.Controllers
{
    [TestClass]
    public abstract class when_working_with_the_product_controller : SpecBase
    {
        protected ProductController _controller;
        protected Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();

        protected override void Establish_context()
        {
            base.Establish_context();

            this._controller = new ProductController(_productRepository.Object);
        }

        protected abstract void Execute();
    }

    [TestClass]
    public class and_loading_all_the_products : when_working_with_the_product_controller
    {
        private Task<ActionResult> _result;

        protected override void Establish_context()
        {
            base.Establish_context();
            base._productRepository.Setup(r => r.GetAll()).Returns(Task.FromResult(Data.Products));
        }

        protected override void Execute()
        {
            _result = _controller.Index();
        }

        [TestMethod]
        public void then_the_repository_get_all_is_called()
        {
            Execute();
            base._productRepository.Verify(r => r.GetAll(), Times.Once);
        }

        [TestMethod]
        public void then_the_model_gets_populated()
        {
            Execute();
            var viewResult = (ViewResult)_result.Result;
            var expected = Data.Products;
            var actual = (List<Product>)viewResult.Model;
            actual.ShouldEqual(expected);
        }
    }
}
