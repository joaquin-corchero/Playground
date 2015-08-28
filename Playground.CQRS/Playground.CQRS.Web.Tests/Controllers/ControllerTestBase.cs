using NBehave.Spec.MSTest;
using Playground.CQRS.Web.Models;

namespace Playground.CQRS.Web.Tests.Controllers
{
    public abstract class ControllerTestBase : SpecBase
    {
        protected SessionTestModel _sessionTestModel;
        protected AppSettingModel _appSettingModel;
        protected ServerVariablesModel _serverVariablesModel;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._sessionTestModel = new SessionTestModel(1);
            this._appSettingModel = new AppSettingModel("The variable");
            this._serverVariablesModel = new ServerVariablesModel(new System.Collections.Specialized.NameValueCollection());

        }
    }
}
