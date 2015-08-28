using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Playground.Web01.Domain;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor;
using Playground.Web01.Domain.Services;
using Microsoft.Framework.ConfigurationModel;
using Playground.Web01.Domain.Repositories;

namespace Playground.Web01
{
    public class Startup
    {
        public Startup()
        {
            var config = new Configuration();
            config.AddEnvironmentVariables();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<ITestService, TestService> ();
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
