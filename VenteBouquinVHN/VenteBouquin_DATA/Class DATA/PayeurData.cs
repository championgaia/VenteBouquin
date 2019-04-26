using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class PayeurData
    {
        public int CodePayeur { get; set; } //idPayeur
        public string CodeUtilisateur { get; set; } //string utilisateur dans la bdd local
        public PersonneData Personne { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region Constructeur par deffault
        public PayeurData() { }
        #endregion
        #region Constructeur par codePayeur
        public PayeurData(int codePayeur)
        {
            var payeur = context.Utilisateurs
                .Where(c => c.IdUtilisateur == codePayeur)
                .ToList().FirstOrDefault();
            if (payeur != null)
            {
                CodePayeur = payeur.IdUtilisateur;
                CodeUtilisateur = payeur.CodeUtilisateur;
                Personne = new PersonneData
                {
                    CodePersonne = payeur.Personne.IdPersonne,
                    Nom = payeur.Personne.Nom,
                    Prenom = payeur.Personne.Prenom,
                    DateNaissance = payeur.Personne.DateNaissance
                };
                //manque liste d'adresse
            }
        }
        #endregion
        #region Constructeur par codeUtilisateur
        public PayeurData(string codeUtilisateur)
        {
            var payeur = context.Utilisateurs
                .Where(c => c.CodeUtilisateur == codeUtilisateur)
                .ToList().FirstOrDefault();
            if (payeur != null)
            {
                CodePayeur = payeur.IdUtilisateur;
                CodeUtilisateur = payeur.CodeUtilisateur;
                Personne = new PersonneData
                {
                    CodePersonne = payeur.Personne.IdPersonne,
                    Nom = payeur.Personne.Nom,
                    Prenom = payeur.Personne.Prenom,
                    DateNaissance = payeur.Personne.DateNaissance
                };
                //manque liste d'adresse
            }
        }
        #endregion
        #region CreatePayeurData
        public void CreatePayeurData(PayeurData payeurdata)
        {
            //besoin db insert
            payeurdata.Personne.CreateNewPersonne(payeurdata.Personne);
            //context = new VenteBouquinContext();
            var codePersonne = context.Personnes
                .Where(c => c.DateNaissance == payeurdata.Personne.DateNaissance && c.Nom == payeurdata.Personne.Nom && c.Prenom == payeurdata.Personne.Prenom)
                .ToList()
                .FirstOrDefault()
                .IdPersonne;
            context.Utilisateurs.AddOrUpdate(new Utilisateur
            {
                CodeUtilisateur = payeurdata.CodeUtilisateur,
                FkPersonne =  codePersonne
            });
            context.SaveChanges();
        }
        #endregion
    }
    internal class PayeurDatas
    {
        public List<PayeurData> ListePayeur { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region Constructeur par deffault
        public PayeurDatas()
        {
            ListePayeur = new List<PayeurData>();
            //besoin contexte
            var monListeU = context.Utilisateurs
                .Distinct()
                .ToList();
            foreach (var item in monListeU)
            {
                ListePayeur.Add(new PayeurData
                {
                    CodePayeur = item.IdUtilisateur,
                    CodeUtilisateur = item.CodeUtilisateur,
                    Personne = new PersonneData
                    {
                        CodePersonne = item.Personne.IdPersonne,
                        Nom = item.Personne.Nom,
                        Prenom = item.Personne.Prenom,
                        DateNaissance = item.Personne.DateNaissance
                    }
                });
            }
            //manque liste d'adresse
        }
        #endregion
    }
}
