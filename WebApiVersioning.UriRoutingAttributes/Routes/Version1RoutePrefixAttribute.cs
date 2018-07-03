using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiVersioning.UriRoutingAttributes.Routes
{
    public class Version1RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v1)}";
        private const string PrefixRouteBase = RouteBase + "/";

        /*
         The main purpose of this attribute class is to encapsulate the API/V1 part of the route template so that we don’t have to copy and paste it over all of the controllers. Let’s add this ApiVersion1RoutePrefixAttribute to the HomeController of V1.
        */
        public Version1RoutePrefixAttribute(string routePrefix) : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {

        }
    }
}