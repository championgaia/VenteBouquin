using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class LigneDeCommandeModel
    {
        public int CodeLigneCommandeM { get; set; }
        public int QuantiteM { get; set; }
        public CommandeModel LaCommandeM { get; set; }
        public LivreModel LeLivreM { get; set; }
        public PromotionModel LaPromoM { get; set; }
        #region constructeur par deffaut
        public LigneDeCommandeModel() { }
        #endregion
    }
    public class LigneDeCommandeModels
    {
        public List<LigneDeCommandeModel> ListeLigneCommande { get; set; }
        #region constructeur par deffaut
        public LigneDeCommandeModels() { }
        #endregion
        #region constructeur par codeCommande
        public LigneDeCommandeModels(int codeCommande)
        {
            ListeLigneCommande = new CommandeModel(codeCommande).LesLignesM;
        }
        #endregion
    }
}