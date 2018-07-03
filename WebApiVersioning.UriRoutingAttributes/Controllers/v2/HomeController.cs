using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiVersioning.UriRoutingAttributes.Routes;

namespace WebApiVersioning.UriRoutingAttributes.Controllers.v2
{
    [Version2RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        [Route("GetCustomers")]
        [HttpGet]
        public string GetCustomers()
        {
            return "v2 GetCustomers";
        }
    }
}
