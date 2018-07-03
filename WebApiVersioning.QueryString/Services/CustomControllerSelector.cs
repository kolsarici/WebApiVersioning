using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiVersioning.QueryString.Services
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
            if(controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                var version = GetVersionFromQueryString(request);

                var newControllerName = string.Concat(controllerName, "V", version);

                HttpControllerDescriptor versionedControllerDesciptor;

                if(controllers.TryGetValue(newControllerName, out versionedControllerDesciptor))
                {
                    return versionedControllerDesciptor;
                }
                return controllerDescriptor;
            }
            return null;
        }

        private string GetVersionFromQueryString(HttpRequestMessage request)
        {
            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);

            var version = query["v"];
            if(version != null)
            {
                return version;
            }
            return "1";
        }
    }
}