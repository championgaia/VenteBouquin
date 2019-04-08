using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
{
    public class ListeLivreViewModel
    {
        public List<LivreModel> ListeLivreVM { get; set; }
        #region MyRegion
        public ListeLivreViewModel()
        {

        }
        #endregion
        #region MyRegion
        public ListeLivreViewModel(int codeCategory)
        {
            ListeLivreVM = new LivreModels(codeCategory).ListeLivreM;
        }
        #endregion
    }
}