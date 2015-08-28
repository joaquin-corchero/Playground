using Playground.CQRS.Domain.Commands.BlogCommands;
using Playground.CQRS.Infrastructure.Messaging;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly ICommandBus _commandBus;

        public HomeController(ICommandBus commandBus)
        {
            this._commandBus = commandBus;
        }

        public ActionResult Index()
        {
            this._commandBus.Execute(new CreateBlogCommand("FirstCommand", "http://www.google.com"));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}