using Microsoft.AspNet.Identity;
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
            LivreCategoryViewModel livreCategoryViewModel = new LivreCategoryViewModel();
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
        [Authorize]
        public ActionResult CreatePayeur()
        {
            var codeUtilisateur = User.Identity.GetUserId();
            PayeurViewModel payeur = new PayeurViewModel(codeUtilisateur);
            return View(payeur);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreatePayeur(PayeurViewModel payeurVM)
        {
            payeurVM.CreatePayeurViewModel(payeurVM);
            return RedirectToAction("GetPayeur", new { codePayeur = 0 });//a modifier
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
        [Authorize]
        public ActionResult CreateCommande(List<string> mesCodeISBN)
        {
            string codeUtilisateur = User.Identity.GetUserId();
            PayeurViewModel payeur = new PayeurViewModel(codeUtilisateur);
            if (payeur != null)
            {
                CreateCommandeViewModel commande = new CreateCommandeViewModel(mesCodeISBN, codeUtilisateur);
                return View(commande);
            }
            else
                return RedirectToAction("CreatePayeur");
        }
        #endregion
        #region CreateCommande
        [HttpPost]
        public ActionResult CreateCommande(CreateCommandeViewModel createCommande)
        {
            createCommande.CreateCommande(createCommande);
            return RedirectToAction("Index");
        }
        #endregion
        #endregion
    }
}