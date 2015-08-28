using Microsoft.AspNet.Mvc;
using Playground.Web01.Domain.Services;
using Playground.Web01.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Playground.Web01.Controllers
{

    public class HomeController : Controller
    {
        [FromServices]
        public ITestService _testService { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TodoItemViewModel());            
        }

        [HttpPost]
        public IActionResult Index(TodoItemViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return View(model);
        }

        public IActionResult Content()
        {
            return new ContentResult() { Content = "This is a content result" };
        }

        public IActionResult ContentFromService()
        {
            return new ContentResult() { Content = this._testService.GetString() };
        }

    }
}
