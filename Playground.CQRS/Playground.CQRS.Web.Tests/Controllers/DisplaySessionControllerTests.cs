using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using Playground.CQRS.Web.AppModelBinders;
using Playground.CQRS.Web.Controllers;
using Playground.CQRS.Web.Models;
using Playground.CQRS.Web.Repositories;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Tests.Controllers
{
    public class when_working_with_the_display_session_controller : ControllerTestBase
    {
        protected SessionTestController _controller;
        protected Mock<ISessionRepository> _sessionRepository;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._sessionRepository = new Mock<ISessionRepository>();
            this._controller = new SessionTestController(this._sessionRepository.Object);
        }
    }

    [TestClass]
    public class and_loading_the_index_action : when_working_with_the_display_session_controller
    {
        [TestMethod]
        public void then_the_model_is_populated()
        {
            var expected = base._sessionTestModel.Number;
            var result = (PartialViewResult)this._controller.Display(base._sessionTestModel);
            var actual = ((SessionTestModel)result.Model).Number;
            actual.ShouldEqual(expected);
        }
    }

    [TestClass]
    public class and_incresing_the_value : when_working_with_the_display_session_controller
    {
        [TestMethod]
        public void then_the_set_value_from_the_repo_is_called()
        {
            this._controller.Increase(base._sessionTestModel);
            var newValue = base._sessionTestModel.Number + 1;
            this._sessionRepository.Verify(r => r.SetValue(SessionTestModelBinder.variableName, newValue, _controller.ControllerContext), Times.Once);
        }
    }
}
