using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        [HttpGet]
        public ActionResult CreatePayeur(string idClient)
        {
            var codeUtilisateur = User.Identity.GetUserId();
            var email = User.Identity.Name;
            PayeurViewModel payeurVM1 = new PayeurViewModel(codeUtilisateur, email);
            return View(payeurVM1);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreatePayeur(PayeurViewModel payeurVM2)
        {
            payeurVM2.PayeurVM.LoginM = User.Identity.Name;
            payeurVM2.PayeurVM.RoleM = Roles.GetRolesForUser(User.Identity.Name).FirstOrDefault() ?? "invidual account";
            //This is a direct read from the enabled attribute of the roleManager element in the web.config:
            //< configuration >
            // < system.web >
            //   < roleManager enabled = "true" />
            //  </ system.web >
            //</ configuration >
            //<roleManager enabled="true" /> 
            payeurVM2.PayeurVM.PasswordM = User.Identity.AuthenticationType;
            payeurVM2.CreatePayeurViewModel(payeurVM2);
            return RedirectToAction("Index");
        }
        #endregion
        #endregion
        #region Commande
        //public ActionResult AddPanier(string codeISBN)
        //{
        //    PanierViewModel panier = new PanierViewModel(codeISBN);
        //    return View(panier);
        //}
        #endregion
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
            if (payeur.PayeurVM.CodeUtilisateurM != null)
            {
                CreateCommandeViewModel commande = new CreateCommandeViewModel(mesCodeISBN, codeUtilisateur);
                return View(commande);
            }
            else
                return RedirectToAction("CreatePayeur", new { idClient = codeUtilisateur });
        }
        #endregion
        #region CreateCommande post
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