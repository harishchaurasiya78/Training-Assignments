using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingDemo.Helpers
{
    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route,
            string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey)) return false;
            string value = values[routeKey]?.ToString() ?? "";
            return Guid.TryParse(value, out _);
        }
    }
}
