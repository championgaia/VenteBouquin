using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class PersonneData
    {
        public int CodePersonne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public AdresseData Adresse { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region Constructreur par déffaut
        public PersonneData() { }
        #endregion
        #region Constructeur par codePersonne
        public PersonneData(int codePersonne)
        {
            var personne = context.Personnes.FirstOrDefault(c => c.IdPersonne == codePersonne);
            if (personne != null)
            {
                CodePersonne = personne.IdPersonne;
                Nom = personne.Nom;
                Prenom = personne.Prenom;
                DateNaissance = personne.DateNaissance;
                Adresse = new AdresseData(personne.Adresse.IdAdresse);
            }
        }
        #endregion
    }
    internal class PersonneDatas
    {
        public List<PersonneData> ListePersonne { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region Constructeur par deffault
        public PersonneDatas()
        {
            ListePersonne = new List<PersonneData>();
            //besoin contexte
            foreach (var item in context.Personnes)
            {
                ListePersonne.Add(new PersonneData
                {
                    CodePersonne = item.IdPersonne,
                    Nom = item.Nom,
                    Prenom = item.Prenom,
                    DateNaissance = item.DateNaissance,
                    Adresse = new AdresseData(item.Adresse.IdAdresse)
                });
            }
        }
        #endregion
        
    }
}
