using System;
using System.Collections.Generic;
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
    }
    internal class PersonneDatas
    {
        public List<PersonneData> ListePersonne { get; set; }
        #region Constructeur par deffault
        public PersonneDatas()
        {

        }
        #endregion
        #region Constructeur
        public PersonneDatas(int codePersonne)
        {
            ListePersonne = new List<PersonneData>();
            //besoin contexte
        }
        #endregion
    }
}
