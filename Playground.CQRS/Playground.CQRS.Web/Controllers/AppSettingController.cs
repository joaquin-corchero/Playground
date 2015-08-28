using Playground.CQRS.Web.Models;
using System.Web.Mvc;

namespace Playground.CQRS.Web.Controllers
{
    public class AppSettingController : Controller
    {
        // GET: AppSetting
        public PartialViewResult Display(AppSettingModel model)
        {
            return PartialView(model);
        }
    }
}