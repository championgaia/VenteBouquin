using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvisFormation.WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "1",
             url: "formation/{nomSeo}",
             defaults: new { controller = "Formation", action = "DetailFormation" }
         );
            routes.MapRoute(
              name: "f",
              url: "toutes-les-formations",
              defaults: new { controller = "Formation", action = "ToutesLesFormations" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
