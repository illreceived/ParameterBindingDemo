using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace WebApi.Controllers
{
    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override string ToString()
        {
            return $"I am a range from {Min} to {Max}";
        }
    }

    public class RangeModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Range))
            {
                return false;
            }

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }


            string key;
            switch (val.RawValue)
            {
                case string s:
                   key = s;
                   break;

                case IEnumerable<string> e:
                   key = e.FirstOrDefault();
                   break;
                default:
                   bindingContext.ModelState.AddModelError(
                   bindingContext.ModelName, "Wrong value type");
                   return false;
            }

            var parts = key.Split('-');
            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0], out int min))
                {
                    if (int.TryParse(parts[1], out int max))
                    {
                        bindingContext.Model = new Range() { Min = min, Max = max };
                        return true;
                    }
                }
            }

            bindingContext.ModelState.AddModelError(
        bindingContext.ModelName, "Cannot convert value to Range");
            return false;
        }
    }

}