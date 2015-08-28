using Playground.CQRS.Web.AppModelBinders;
using Playground.CQRS.Web.Models;
using Playground.CQRS.Web.Repositories;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Controllers
{
    public class SessionTestController : Controller
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionTestController(ISessionRepository sessionRepository)
        {
            this._sessionRepository = sessionRepository;
        }

        [HttpGet]
        public PartialViewResult Display(SessionTestModel sessionTestModel)
        {
            return PartialView(sessionTestModel);
        }

        [HttpGet]
        public ActionResult Increase(SessionTestModel sessionTestModel)
        {
            this._sessionRepository.SetValue(SessionTestModelBinder.variableName, sessionTestModel.Number + 1, this.ControllerContext);
            return RedirectToAction("Index", "Home");
        }
    }
}