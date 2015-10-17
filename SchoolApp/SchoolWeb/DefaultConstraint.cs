using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SchoolWeb
{
    public class DefaultConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext.Request.Url.LocalPath.StartsWith("/svc/", StringComparison.CurrentCultureIgnoreCase))
                return false;
            return true;
        }
    }
}