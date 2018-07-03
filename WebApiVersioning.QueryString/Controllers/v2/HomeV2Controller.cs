using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiVersioning.QueryString.Controllers.v2
{
    public class HomeV2Controller : ApiController
    {
        [HttpGet]
        public string GetCustomers()
        {
            return "v2 GetCustomers";
        }
    }
}
