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
        private VenteBouquinContext context = new VenteBouquinContext();
        #region constructeur par déffaut
        public AdresseData() { }
        #endregion
        #region Constructeur
        public AdresseData(int codeAdresse)
        {
            //context besoin
            var addresse = context.Adresses.First(c => c.IdAdresse == codeAdresse);
            if (addresse != null)
            {
                CodeAdresse = addresse.IdAdresse;
                NomRue = addresse.NomRue;
                NumeroRue = addresse.NumeroRue;
                AdresseComplementaire = addresse.AdresseComplementaire;
                NomVille = addresse.NomVille;
                CodePostale = addresse.CodePostal;
                NomPays = addresse.NomPays;
            }
        }
        #endregion
    }
}
