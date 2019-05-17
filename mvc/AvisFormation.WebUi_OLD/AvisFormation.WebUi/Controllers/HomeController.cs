using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //recurpere 4 ou 5 formations de maniere aleatoire
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
    }
}