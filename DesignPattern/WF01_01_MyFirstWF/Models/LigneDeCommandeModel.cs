using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF01_01_MyFirstWF.Models
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
}