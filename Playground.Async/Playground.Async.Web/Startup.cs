using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Playground.Async.Web.Startup))]
namespace Playground.Async.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
