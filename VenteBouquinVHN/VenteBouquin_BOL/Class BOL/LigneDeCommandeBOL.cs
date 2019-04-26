using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA;

namespace VenteBouquin_BOL.Class_BOL
{
    internal class LigneDeCommandeBOL
    {
        public int CodeLigneCommande { get; set; }
        public int Quantite { get; set; }
        public CommandeBOL LaCommande { get; set; }
        public PromotionBOL LaPromo { get; set; }
        #region constructeur par deffaut
        public LigneDeCommandeBOL() { }
        #endregion
    }
    internal class LigneDeCommandeBOLs
    {
        public List<LigneDeCommandeBOL> ListeLigneCommande { get; set; }
        #region constructeur par deffaut
        public LigneDeCommandeBOLs() {}
        #endregion
        #region constructeur par codeCommande
        public LigneDeCommandeBOLs(int codeCommande)
        {
            ListeLigneCommande = new CommandeBOL(codeCommande).LesLignes;
        }
        #endregion
    }
}
