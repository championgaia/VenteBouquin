using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class PersonneBOL
    {
        public int CodePersonne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public AdresseBOL Adresse { get; set; }
        #region Constructeur par deffault
        public PersonneBOL() { }
        #endregion
        #region Constructeur
        public PersonneBOL(int codePersonne)
        {
            /////////////////////////////
        }
        #endregion
    }
}
