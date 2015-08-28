using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.Modules.Module1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var test = Request.IsAuthenticated;
            if(Session["Test"] == null)
                ViewBag.Message = Session.SessionID + "Can't take the session";
            else
                ViewBag.Message = Session["Test"];

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}