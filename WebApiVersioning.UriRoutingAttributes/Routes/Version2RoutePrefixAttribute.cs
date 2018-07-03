using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiVersioning.UriRoutingAttributes.Routes
{
    public class Version2RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v2)}";
        private const string PrefixRouteBase = RouteBase + "/";

        public Version2RoutePrefixAttribute(string routePrefix) : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {

        }
    }
}