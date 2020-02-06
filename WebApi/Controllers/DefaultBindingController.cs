using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParameterBindingDemo
{
    public class DefaultBindingController : ApiController
    {


        // GET api/<controller>/5
        public string Get(int id, string value, TimeSpan timeSpan)
        {
            return $"id: {id}, value: {value}, timeSpan: {timeSpan}";
        }


        // POST api/<controller>
        public string Post(string value)
        {
            return $"received {value}";
        }

        public string Post(SimpleObject value)
        {
            return $"received {value.ToString()}";

        }

    }

}