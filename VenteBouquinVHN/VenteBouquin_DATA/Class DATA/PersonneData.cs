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
        public List<AdresseData> ListeAdresse { get; set; }
        private VenteBouquinContext context = new VenteBouquinContext();
        #region MyRegion
        public PersonneData() { }
        #endregion
        #region Constructeur
        public PersonneData(int codePersonne)
        {
            //////////////////////////////////////////////
        }
        #endregion
        #region CreateNewPersonne
        public void CreateNewPersonne(PersonneData personne)
        {
            context.Personnes.AddOrUpdate(new Personne
            {
                Nom = personne.Nom,
                Prenom = personne.Prenom,
                DateNaissance = personne.DateNaissance,
                FkAdresse = 2 //entre en dur
            });
            context.SaveChanges();
        }
        #endregion
    }
    internal class PersonneDatas
    {
        public List<PersonneData> ListePersonne { get; set; }
        #region Constructeur par deffault
        public PersonneDatas()
        {
            ListePersonne = new List<PersonneData>();
            //besoin contexte
        }
        #endregion
        
    }
}
