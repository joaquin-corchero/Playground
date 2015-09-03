using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Domain.Products;
using Playground.Async.Domain.Repositories;
using Playground.Async.Web.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Playground.Async.Tests.Web.Controllers
{
    [TestClass]
    public abstract class when_working_with_the_product_controller : SpecBase
    {
        protected ProductController _controller;
        protected Mock<IProductQueryRepository> _productQueryRepository = new Mock<IProductQueryRepository>();

        protected override void Establish_context()
        {
            base.Establish_context();

            this._controller = new ProductController(_productQueryRepository.Object);
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
            base._productQueryRepository.Setup(r => r.GetAll()).Returns(Task.FromResult(Data.Products));
        }

        protected override void Execute()
        {
            _result = _controller.Index();
        }

        [TestMethod]
        public void then_the_repository_get_all_is_called()
        {
            Execute();
            base._productQueryRepository.Verify(r => r.GetAll(), Times.Once);
        }

        [TestMethod]
        public void then_the_model_gets_populated()
        {
            Execute();
            var viewResult = (ViewResult)_result.Result;
            var expected = Data.Products;
            var actual = (List<Domain.Products.Product>)viewResult.Model;
            actual.ShouldEqual(expected);
        }
    }
}
