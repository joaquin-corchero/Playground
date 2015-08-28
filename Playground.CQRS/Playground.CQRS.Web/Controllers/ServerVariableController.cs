using Playground.CQRS.Web.Models;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Controllers
{
    public class ServerVariableController : Controller
    {
        // GET: ServerVariable
        public PartialViewResult Display(ServerVariablesModel serverVariables)
        {
            return PartialView(serverVariables);
        }
    }
}