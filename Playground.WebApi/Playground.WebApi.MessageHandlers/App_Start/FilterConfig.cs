using System.Web;
using System.Web.Mvc;

namespace Playground.WebApi.MessageHandlers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
