using Playground.CQRS.Web.Models;
using System.Web.Mvc;

namespace Playground.CQRS.Web.AppModelBinders
{
    public class SessionTestModelBinder : IModelBinder
    {
        public const string variableName = "SessionNumber";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Session[variableName] == null)
                controllerContext.HttpContext.Session[variableName] = 0;

            return new SessionTestModel((int)controllerContext.HttpContext.Session[variableName]);
        }
    }
}