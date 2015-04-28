using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MyWeb.RouteConstraint
{
    public class NotFoundConstraint: IRouteConstraint
    {

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext.Request.RawUrl == "/")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}