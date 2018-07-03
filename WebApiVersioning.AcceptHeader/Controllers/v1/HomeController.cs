using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiVersioning.AcceptHeader.Controllers.v1
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string GetCustomers()
        {
            return "v1 GetCustomers";
        }
    }
}
