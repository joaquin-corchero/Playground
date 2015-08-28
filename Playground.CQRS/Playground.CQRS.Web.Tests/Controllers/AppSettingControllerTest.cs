using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using Playground.CQRS.Web.Controllers;
using Playground.CQRS.Web.Models;

namespace Playground.CQRS.Web.Tests.Controllers
{
    public class when_working_with_the_app_setting_controller : ControllerTestBase
    {
        protected AppSettingController _controller;
        protected override void Establish_context()
        {
            base.Establish_context();
            this._controller = new AppSettingController();
        }
    }

    [TestClass]
    public class and_executing_the_display_action : when_working_with_the_app_setting_controller
    {
        [TestMethod]
        public void then_the_model_is_set()
        {
            var expected = base._appSettingModel.FirstVariable;
            var actual = (AppSettingModel)this._controller.Display(base._appSettingModel).Model;
            actual.FirstVariable.ShouldEqual(expected);
        }
    }
}
