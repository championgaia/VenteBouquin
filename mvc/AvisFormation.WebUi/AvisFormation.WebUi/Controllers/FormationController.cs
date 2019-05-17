using AvisFormation.WebUi.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ToutesLesFormations()
        {
            FormationRepository repository = new FormationRepository();

            var vm = new ToutesLesFormationsViewModel();
            vm.Formations = repository.GetFormations();
            vm.Ville = "Rouen"; 

            return View(vm);
        }
        public ActionResult DetailFormation(string nomSeo)
        {
            FormationRepository repository = new FormationRepository();
            var formation = repository.GetFormationByNomSeo(nomSeo);

            if (formation == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var noteMoyenne = Math.Round(formation.Avis.Select(f=>f.Note).DefaultIfEmpty(0).Average(),2);

            var vm = new DetailFormationViewModel();
            vm.FormationInstance = formation;
            vm.NoteMoyenne = noteMoyenne;

            return View(vm);
        }
    }
}