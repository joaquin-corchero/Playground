using Playground.CQRS.Web.AppModelBinders;
using Playground.CQRS.Web.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Playground.CQRS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(SessionTestModel), new SessionTestModelBinder());
            ModelBinders.Binders.Add(typeof(ServerVariablesModel), new ServerVariablesModelBinder());
            ModelBinders.Binders.Add(typeof(AppSettingModel), new AppSettinsModelBinder());
        }
    }
}
