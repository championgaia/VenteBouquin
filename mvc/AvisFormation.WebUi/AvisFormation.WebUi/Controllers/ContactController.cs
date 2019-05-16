using AvisFormation.WebUi.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // public ActionResult EnvoyerMessage(string nom,string email,string msg)
        public ActionResult EnvoyerMessage(ContactViewModel contactViewModel)
        {
            var c = new MessageDb();
            c.Email = contactViewModel.Email;
            c.Msg = contactViewModel.Msg;
            c.Nom = contactViewModel.Nom;

            using (var context = new AfDbEntities())
            {
                context.MessageDb.Add(c);
                context.SaveChanges();
            }

            TempData["Message"] = "Votre message a bien été enregistré";
            return RedirectToAction("Index","Contact");

        }


    }
}