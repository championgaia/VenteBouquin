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
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public PersonneData Personne { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region Constructeur par deffault
        public PayeurData() { }
        #endregion
        #region Constructeur par codePayeur
        public PayeurData(int codePayeur)
        {
            var payeur = context.Utilisateurs
                .FirstOrDefault(c => c.IdUtilisateur == codePayeur);
            if (payeur != null)
            {
                CodePayeur = payeur.IdUtilisateur;
                CodeUtilisateur = payeur.CodeUtilisateur;
                Login = payeur.Login;
                Password = payeur.Password;
                Role = payeur.Role;
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
                .FirstOrDefault(c => c.CodeUtilisateur == codeUtilisateur);
            if (payeur != null)
            {
                CodePayeur = payeur.IdUtilisateur;
                CodeUtilisateur = payeur.CodeUtilisateur;
                Login = payeur.Login;
                Password = payeur.Password;
                Role = payeur.Role;
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
    }
}
