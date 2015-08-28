using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Playground.Modules.Site.Startup))]
namespace Playground.Modules.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
