using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace WebApi.Controllers
{
    public class ModelBindingController : ApiController
    {
        public IHttpActionResult Get(int id, [ModelBinder(typeof(RangeModelBinder))] Range range)
        {
            if (ModelState.IsValid)
            {
                return Ok(range.ToString());
            }
            return BadRequest(ModelState);
        }

        //public IHttpActionResult Get(int id, [ModelBinder] Range range)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Ok(range.ToString());
        //    }
        //    return BadRequest(ModelState);
        //}
    }
}