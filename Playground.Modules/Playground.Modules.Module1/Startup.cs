using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Playground.Modules.Module1.Startup))]
namespace Playground.Modules.Module1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
