using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AplicacionMantenimiento
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "rentar",                                           // Route name
                url: "rentar",                            // URL with parameters
                defaults: new { controller = "Alquiler", action = "Create", }  // Parameter defaults
            );

            routes.MapRoute(
                name: "mis-peliculas",                                           // Route name
                url: "mis-peliculas",                            // URL with parameters
                defaults: new { controller = "Alquiler", action = "Index", }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
