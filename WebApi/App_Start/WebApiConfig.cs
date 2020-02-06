using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ValueProviders;
using WebApi.Controllers;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var provider = new SimpleModelBinderProvider(typeof(Range), new RangeModelBinder());
            //config.Services.Insert(typeof(ModelBinderProvider), 0, provider);

            //config.Services.Add(typeof(ValueProviderFactory), new HeaderValueProviderFactory());

            //config.ParameterBindingRules.Add(p =>
            //{
            //    if (p.ParameterType == typeof(string) && p.ParameterName == "path" &&
            //        p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Get))
            //    {
            //        return new EnvironmentBinding(p, "path");
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //});

        }
    }
}
