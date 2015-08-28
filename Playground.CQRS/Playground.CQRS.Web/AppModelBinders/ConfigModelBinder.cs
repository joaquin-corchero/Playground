using Playground.CQRS.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace Playground.CQRS.Web.AppModelBinders
{
    public class AppSettinsModelBinder : IModelBinder
    {
        public const string firstVariableName = "FirstVariable";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new AppSettingModel(ConfigurationManager.AppSettings[firstVariableName]);
        }
    }
}