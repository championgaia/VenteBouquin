using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class PayeurData
    {
        public int CodePayeur { get; set; }
        public string CodeUtilisateur { get; set; }
        public PersonneData Personne { get; set; }
    }
    internal class PayeurDatas
    {
        public List<PayeurData> ListePayeur { get; set; }
        #region Constructeur par deffault
        public PayeurDatas()
        {

        }
        #endregion
        #region Constructeur
        public PayeurDatas(int codeUtilisateur)
        {
            ListePayeur = new List<PayeurData>();
            //besoin contexte
        }
        #endregion
    }
}
