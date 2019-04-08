using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class PayeurBOL
    {
        public int CodePayeur { get; set; }
        public string CodeUtilisateur { get; set; }
        public PersonneBOL Personne { get; set; }
    }
    internal class PayeurBOLs
    {
        public List<PayeurBOL> ListePayeur { get; set; }
        #region Constructeur par deffault
        public PayeurBOLs()
        {

        }
        #endregion
        #region Constructeur
        public PayeurBOLs(int codeUtilisateur)
        {
            ListePayeur = new List<PayeurBOL>();
            //besoin contexte
        }
        #endregion
    }
}
