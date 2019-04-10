using System;
using System.Collections.Generic;
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
        #region CreatePayeurData
        public void CreatePayeurData(PayeurData payeurdata)
        {
            //besoin db insert
            throw new NotImplementedException();
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

        }
        #endregion
        #region Constructeur par codePayeur
        public PayeurDatas(int codePayeur)
        {
            ListePayeur = new List<PayeurData>();
            //besoin contexte
            var monListeU = context.Utilisateurs
                .Include("Personne")
                .Select(c => c).Distinct()
                .Where(c => c.IdUtilisateur == codePayeur || codePayeur == 0)
                .ToList();
            foreach (var item in monListeU)
            {
                ListePayeur.Add(new PayeurData {
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
