using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiVersioning.AcceptHeader.Services
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _configuration;
        public CustomControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();

            var routeData = request.GetRouteData();

            var controllerName = (string)routeData.Values["controller"];

            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                var version = GetVersionFromAcceptHeader(request);

                var newControllerName = string.Concat(controllerName, "V", version);

                HttpControllerDescriptor versionedControllerDesciptor;

                if (controllers.TryGetValue(newControllerName, out versionedControllerDesciptor))
                {
                    return versionedControllerDesciptor;
                }
                return controllerDescriptor;
            }
            return null;
        }

        private string GetVersionFromAcceptHeader(HttpRequestMessage request)
        {
            var accept = request.Headers.Accept;

            foreach(var mime in accept)
            {
                if(mime.MediaType == ConfigurationManager.AppSettings["MediaType"])
                {
                    var value = mime.Parameters
                                    .Where(v => v.Name.Equals(ConfigurationManager.AppSettings["VersionAcceptHeaderName"], StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();

                    return value.Value;
                }
            }
            return "1";
        }
    }
}