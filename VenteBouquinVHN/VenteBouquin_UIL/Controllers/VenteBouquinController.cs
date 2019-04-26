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
        #region Livre
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
        #endregion
        #region Payeur
        #region CreatePayeur
        public ActionResult CreatePayeur()
        {
            string codeUtilisateur = User.Identity.Name;
            PayeurViewModel payeur = new PayeurViewModel(codeUtilisateur);
            return View(payeur);
        }
        [HttpPost]
        public ActionResult CreatePayeur(PayeurViewModel payeurVM)
        {
            payeurVM.CreatePayeurViewModel(payeurVM);
            return RedirectToAction("GetPayeur", new { codePayeur = 0 });
        }
        #endregion
        #endregion
        //#region Commande
        //public ActionResult AddPanier(string codeISBN)
        //{
        //    PanierViewModel panier = new PanierViewModel(codeISBN);
        //    return View(panier);
        //}
        //#endregion
        #region Commande
        #region Panier
        public ActionResult AddPanier(List<string> mesCodeISBN)
        {
            //add codeISBN via variable locale
            PanierViewModel panier = new PanierViewModel(mesCodeISBN);
            return View(panier);
        }
        #endregion
        #region CreateCommande
        public ActionResult CreateCommande(List<string> mesCodeISBN, string codePayer)
        {
            CreateCommandeViewModel commande = new CreateCommandeViewModel(mesCodeISBN, codePayer);
            return View(commande);
        }
        #endregion
        #endregion
    }
}