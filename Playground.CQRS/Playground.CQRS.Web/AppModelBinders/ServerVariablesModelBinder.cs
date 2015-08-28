using Playground.CQRS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.CQRS.Web.AppModelBinders
{
    public class ServerVariablesModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new ServerVariablesModel(controllerContext.HttpContext.Request.ServerVariables);
        }
    }
}