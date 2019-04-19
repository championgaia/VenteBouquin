using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VenteBouquin_UIL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //DetailLivre
            routes.MapRoute(
                name: "DetailLivre",
                url: "{controller}/DetailLivre/{codeISBN}",
                defaults: new { controller = "VenteBouquinController", action = "DetailLivre" }
            );
            //route GetLivreParCategory
            routes.MapRoute(
                name: "GetLivreParCategory",
                url: "{controller}/GetLivreParCategory/{codeCategory}",
                defaults: new { controller = "VenteBouquinController", action = "GetLivreParCategory" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
