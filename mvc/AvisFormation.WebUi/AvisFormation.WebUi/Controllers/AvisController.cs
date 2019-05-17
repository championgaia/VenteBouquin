using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using Data;
using AvisFormation.WebUi.Models;

namespace AvisFormation.WebUi.Controllers
{
    [Authorize]
    public class AvisController : Controller
    {
        // GET: Avis
        public ActionResult LaissezUnAvis(int idFormation)
        {
            
            return View(idFormation);
        }
        [HttpPost]
        //public ActionResult SaveComment(string note, string nom, string commentaire, string idFormation)
        public ActionResult SaveComment(AvisViewModel avisViewModel)
        {
            int iIdFormation = 0;
            if (!Int32.TryParse(avisViewModel.IdFormation, NumberStyles.Any, CultureInfo.InvariantCulture, out iIdFormation))
            {
                return RedirectToAction("Index", "Home");
            }

            if(!ModelState.IsValid)
            {
                return View(viewName:"LaissezUnAvis", model:iIdFormation);
            }


            // transforme une string en float
            float fNote = 0;
            if (!float.TryParse(avisViewModel.Note, NumberStyles.Any,CultureInfo.InvariantCulture,out fNote))
            {
                return RedirectToAction("Index","Home");
            }

            Avis a = new Avis();
            a.Description = avisViewModel.Commentaire;
            a.IdFormation = iIdFormation;
            a.Nom = avisViewModel.Nom;
            a.Note = fNote;
            //a.DateAvis = DateTime.Now;

            AvisRepository repository = new AvisRepository();
            repository.AddAvis(a);

            //on a besoin du nomSeo mais on ne connait que l'idFormation
            FormationRepository repo = new FormationRepository();
            var formation = repo.GetFormation(iIdFormation);

            //redirecige l'utilisateur vers la page DetailFormation dont idformation correspond à l'avis.
            return RedirectToAction("DetailFormation","Formation",new {nomSeo= formation.NomSeo });

        }
    }
}