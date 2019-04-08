using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenteBouquin_UIL.Views.VenteBouquin;

namespace VenteBouquin_UIL.Controllers
{
    public class VenteBouquinController : Controller
    {
        // GET: VenteBouquin
        public ActionResult Index()
        {
            LivreCategoryViewModel livreCategoryViewModel = new LivreCategoryViewModel(0);
            return View(livreCategoryViewModel);
        }
    }
}