using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Application.Services;
using Playground.Async.Application.ViewModels;
using Playground.Async.Domain.Products;
using Playground.Async.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Async.Tests.Application.Services
{
    public abstract class when_working_with_the_product_controller_service : SpecBase
    {
        protected ProductControllerService _service;
        protected Mock<IProductQueryRepository> _productQueryRepository = new Mock<IProductQueryRepository>();


        protected override void Establish_context()
        {
            base.Establish_context();

            _service = new ProductControllerService(_productQueryRepository.Object);
        }
    }

    [TestClass]
    public class and_getting_all_the_products : when_working_with_the_product_controller_service
    {
        private Task<List<ProductViewModel>> _result;

        protected override void Establish_context()
        {
            base.Establish_context();

            _productQueryRepository.Setup(r => r.GetAll()).Returns(Task.FromResult(Data.Products));
        }

        private void Execute()
        {
            _result = _service.GetAll();
        }

        [TestMethod]
        public void then_if_there_are_no_records_empty_list_of_models_is_returned()
        {
            _productQueryRepository.Setup(r => r.GetAll()).Returns(Task.FromResult(new List<Product>()));

            Execute();

            _result.Result.Any().ShouldBeFalse();
        }

        [TestMethod]
        public void then_if_there_are_records_the_products_are_returned()
        {
            var expected = ProductViewModel.GetFromProducts(Data.Products);

            Execute();

            var result = _result.Result;
            result.Count.ShouldEqual(expected.Count);
            result.ForEach(i => expected.Any(e => e.ProductId == i.ProductId).ShouldBeTrue());
        }
    }
}
