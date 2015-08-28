using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using Playground.CQRS.Web.Controllers;
using Playground.CQRS.Web.Models;
using System.Linq;

namespace Playground.CQRS.Web.Tests.Controllers
{
    public class when_working_with_the_server_variable_controller : ControllerTestBase
    {
        protected ServerVariableController _controller;
        protected override void Establish_context()
        {
            base.Establish_context();
            this._controller = new ServerVariableController();
        }
    }

    [TestClass]
    public class and_executing_the_server_variable_display_action : when_working_with_the_server_variable_controller
    {
        [TestMethod]
        public void then_the_model_is_set()
        {
            var expected = base._serverVariablesModel;
            var actual = (ServerVariablesModel)this._controller.Display(base._serverVariablesModel).Model;
            actual.ShouldEqual(expected);
        }
    }
}
