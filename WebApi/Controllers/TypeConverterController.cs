using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class TypeConverterController : ApiController
    {
        // GET api/<controller>/5
        public string Post(Colour colour)
        {
     
            return colour.ToString();
        }

    }
}