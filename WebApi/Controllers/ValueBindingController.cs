using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace WebApi.Controllers
{
    public class ValueBindingController : ApiController
    {

        // GET api/<controller>
        //public string Get([ValueProvider(typeof(HeaderValueProviderFactory))] IEnumerable<string> acceptLanguage)
        //{
        //    return string.Join(",", acceptLanguage);
        //}

        public string Get([ModelBinder] IEnumerable<string> acceptLanguage)
        {
            return string.Join(",", acceptLanguage);
        }

    }
}