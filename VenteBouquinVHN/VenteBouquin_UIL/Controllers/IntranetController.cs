using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenteBouquin_UIL.Views.Intranet;

namespace VenteBouquin_UIL.Controllers
{
    public class IntranetController : Controller
    {
        // GET: Intranet
        public ActionResult Index()
        {
            return View();
        }
        #region Payeur
        #region GetPayeurParCodePayeur
        // GET: PayeurParCodePayeur
        public ActionResult GetPayeur(int codePayeur)
        {
            ListePayeurViewModel myListPayeur = new ListePayeurViewModel(codePayeur);
            return View(myListPayeur);
        }
        #endregion
        #region DetailPayeurParCodePayeur
        // DETAIL: PayeurParCodePayeur
        public ActionResult DetailPayeur(int codePayeur)
        {
            PayeurViewModel myPayeur = new PayeurViewModel(codePayeur);
            return View(myPayeur);
        }
        #endregion
        #region CreatePayeur
        public ActionResult CreatePayeur()
        {
            string codeUtilisateur = User.Identity.Name;
            PayeurViewModel payeur = new PayeurViewModel(codeUtilisateur);
            return View(payeur);
        }
        [HttpPost]
        public ActionResult CreatePayeur(PayeurViewModel payeur)
        {
            return RedirectToAction("GetPayeur", new {codePayeur = 0 });
        }
        #endregion

        #endregion
    }
}