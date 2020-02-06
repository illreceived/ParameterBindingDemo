using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParameterBindingDemo
{
    public class AttributeBindingController : ApiController
    {


        // GET api/<controller>/5
        public string Get(int id, [FromBody] string value)
        {
            return $"id: {id}, value: {value}";
        }


        // POST api/<controller>
        public string Post([FromBody] string value)
        {
            return $"received {value}";
        }

        public string Put([FromUri] SimpleObject value)
        {
            return $"received {value.ToString()}";

        }

    }

}