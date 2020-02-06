using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace WebApi.Controllers
{
    public class HeaderValueProvider : IValueProvider
    {
        private Dictionary<string, IEnumerable<string>> _values;

        public HeaderValueProvider(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }
            _values = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var header in actionContext.Request.Headers)
            {
                _values[header.Key.Replace("-","").ToLower()] = header.Value;
            }
        }

        public bool ContainsPrefix(string prefix)
        {
            return _values.Keys.Contains(prefix.ToLower());
        }

        public ValueProviderResult GetValue(string key)
        {
            IEnumerable<string> value;
            if (_values.TryGetValue(key.ToLower(), out value))
            {
                return new ValueProviderResult(value, string.Join(",", value.ToArray()), CultureInfo.InvariantCulture);
            }
            return null;
        }
    }

    public class HeaderValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            return new HeaderValueProvider(actionContext);
        }
    }

}