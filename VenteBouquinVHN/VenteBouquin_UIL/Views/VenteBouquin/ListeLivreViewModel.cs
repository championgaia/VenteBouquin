using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
{
    public class ListeLivreViewModel
    {
        [DisplayName("Malist")]
        public List<LivreModel> ListeLivreVM { get; set; }
        #region constructeur par deffaut
        public ListeLivreViewModel()
        {

        }
        #endregion
        #region constructeur par codeCategory
        public ListeLivreViewModel(int codeCategory)
        {
            ListeLivreVM = new LivreModels(codeCategory).ListeLivreM;
        }
        #endregion
    }
}