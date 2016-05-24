using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Labo_01
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Date", action = "Today", id = UrlParameter.Optional
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional
                // Eerst controller aanroepeen bv Home daarna de actie onder de controller in dit geval index
                }
            );
        }
    }
}
