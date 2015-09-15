using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Playground.WebApi.HostAuthentication.Startup))]
namespace Playground.WebApi.HostAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
