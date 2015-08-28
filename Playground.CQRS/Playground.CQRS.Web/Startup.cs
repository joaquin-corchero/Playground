using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Playground.CQRS.Web.Startup))]
namespace Playground.CQRS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
