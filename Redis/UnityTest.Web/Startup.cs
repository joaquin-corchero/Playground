using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnityTest.Web.Startup))]
namespace UnityTest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
