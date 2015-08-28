using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace UnityTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string _kacheKey = "FirstCacheKey";

        public ActionResult Index()
        {
            Session["testRedisSession"] = string.Format("Message from the redis ression {0}", Session.SessionID);

            if (HttpRuntime.Cache[_kacheKey] == null)
                HttpRuntime.Cache[_kacheKey] = "Hello Vivek";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Session["testRedisSession"];

            Session.Add("ObjectTest", new ModelCached());

            Session.Add("ListTest", new List<ModelCached> { new ModelCached(), new ModelCached() });

            return View();
        }

        [OutputCache(Duration = 20)]
        public ActionResult Contact()
        {
            var cacheProvider = OutputCache.Providers["MyRedisOutputCache"];

            if (cacheProvider.Get("MyCacheItem") == null)
                cacheProvider.Set("MyCacheItem", "Hello, I'm a cache item", DateTime.Now.AddMinutes(5));

            var itemOnCache = cacheProvider.Get("MyCacheItem");

            ViewBag.Message = string.Format("Your contact page. {0} , and from the cache {1}", DateTime.Now, HttpRuntime.Cache[_kacheKey]);

            var model = Session["ListTest"] as List<ModelCached>;

            model.Add(Session["ObjectTest"] as ModelCached);

            return View(model);
        }
    }

    [Serializable]
    public class ModelCached
    {
        public DateTime Date { get; private set; }

        public ModelCached()
        {
            this.Date = DateTime.Now;
        }
    }
}