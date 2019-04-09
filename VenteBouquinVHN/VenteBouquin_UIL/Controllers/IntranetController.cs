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
        // GET: GetPayeurParCodePayeur
        public ActionResult GetPayeur(string codePayeur)
        {
            ListePayeurViewModel myListPayeur = new ListePayeurViewModel(codePayeur);
            return View(myListPayeur);
        }
        #endregion
    }
}