using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //definisco una customRoute

            routes.MapRoute(
                 "MyCustomRoute",
                 "Movies/release/{fristParam}/{secondParam}",
                 new { controller = "Movies", action = "ByReleaseDate", fristParam = UrlParameter.Optional, secondParam = UrlParameter.Optional }
                 //new { fristParam = "//d{4}", secondParam = "//d{4}" } //costrizioni sui parametri in ingresso al metodo
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
