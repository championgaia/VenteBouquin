using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class AdresseData
    {
        public int CodeAdresse { get; set; }
        public int NumeroRue { get; set; }
        public string NomRue { get; set; }
        public string AdresseComplementaire { get; set; }
        public string NomVille { get; set; }
        public string CodePostale { get; set; }
        public string NomPays { get; set; }
        #region constructeur par déffaut
        public AdresseData()
        {

        }
        #endregion
    }
    internal class AddresseDataPlus
    {
        public List<AdresseData> ListeAdresse { get; set; }
        #region Constructeur par déffault
        public AddresseDataPlus()
        {

        }
        #endregion
        #region Constructeur
        public AddresseDataPlus(int codeAdresse)
        {
            ListeAdresse = new List<AdresseData>();
            //context besoin
        }
        #endregion
    }
}
