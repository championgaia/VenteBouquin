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
        // GET: GetLivreParCategory
        public ActionResult GetLivreParCategory(int codeCategory)
        {
            ListeLivreViewModel laListeLivre = new ListeLivreViewModel(codeCategory);
            return View(laListeLivre);
        }
        // Detail : Livre
        public ActionResult DetailLivre(string codeISBN)
        {
            LivreViewModel livre = new LivreViewModel(codeISBN);
            return View(livre);
        }
    }
}