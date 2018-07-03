using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using WebApiVersioning.AcceptHeader.Services;

namespace WebApiVersioning.AcceptHeader
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
            //Replace the Controller Configuration
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));
        }
    }
}
