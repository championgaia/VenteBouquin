using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class AdresseBOL
    {
        public int CodeAdresse { get; set; }
        public int NumeroRue { get; set; }
        public string NomRue { get; set; }
        public string AdresseComplementaire { get; set; }
        public string NomVille { get; set; }
        public string CodePostale { get; set; }
        public string NomPays { get; set; }
        #region constructeur par déffaut
        public AdresseBOL()
        {

        }
        #endregion
    }
    internal class AdresseBOLPlus
    {
        public List<AdresseBOL> ListeAdresse { get; set; }
        #region Constructeur par déffault
        public AdresseBOLPlus()
        {

        }
        #endregion
        #region Constructeur
        public AdresseBOLPlus(int codeAdresse)
        {
            ListeAdresse = new List<AdresseBOL>();
            //context besoin
        }
        #endregion
    }
}
