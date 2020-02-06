using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace WebApi.Controllers
{
    public class ParameterBindingController : ApiController
    {
        public string Get([EnviornmentBinding("path")] string path)
        {
            return path;
        }

        //public string Get(string path)
        //{
        //    return path;
        //}
    }

    public class EnvironmentBinding : HttpParameterBinding
    {
        private string _envVariableName;

        public EnvironmentBinding(HttpParameterDescriptor parameterDescriptor, string envVariableName): base(parameterDescriptor)
        {
            _envVariableName = envVariableName;
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            actionContext.ActionArguments[Descriptor.ParameterName] = Environment.GetEnvironmentVariable(_envVariableName);
            var tsc = new TaskCompletionSource<object>();
            tsc.SetResult(null);
            return tsc.Task;
        }
    }


    public class EnviornmentBindingAttribute : ParameterBindingAttribute
    {
        public EnviornmentBindingAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter.ParameterType == typeof(string))
            {
                return new EnvironmentBinding(parameter, Name);
            }
            return null;
        }

    }

}