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
            //CreatePayeur
            routes.MapRoute(
                name: "CreatePayeur",
                //url: "{controller}/{action}/{idClient}",
                url: "vente-bouquin/creer-payeur/{idClient}",
                defaults: new { controller = "VenteBouquin", action = "CreatePayeur" }
            );
            //CreateCommande
            routes.MapRoute(
                name: "CreateCommande",
                //url: "{controller}/{action}/{mesCodeISBN}",
                url: "vente-bouquin/creer-commande/{mesCodeISBN}",
                defaults: new { controller = "VenteBouquin", action = "CreateCommande" }
            );
            //DetailLivre
            routes.MapRoute(
                name: "DetailLivre",
                //url: "{controller}/{action}/{codeISBN}",
                url: "vente-bouquin/detail-livre/{codeISBN}",
                defaults: new { controller = "VenteBouquin", action = "DetailLivre" }
            );
            //route GetLivreParCategory
            routes.MapRoute(
                name: "GetLivreParCategory",
                //url: "{controller}/{action}/{codeCategory}",
                url : "vente-bouquin/livre-par-category/{codeCategory}",
                defaults: new { controller = "VenteBouquin", action = "GetLivreParCategory"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{cont" +
                "roller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
