﻿using Playground.WebApi.MessageHandlers.Handlers;
using System.Web.Http;

namespace Playground.WebApi.MessageHandlers
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new NaiveAuthenticationHandler());
        }
    }
}