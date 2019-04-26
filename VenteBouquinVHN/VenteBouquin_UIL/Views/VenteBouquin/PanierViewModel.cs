using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
{
    public class PanierViewModel
    {
        public List<LivreModel> MonChoixLivreVM { get; set; }
        #region constructeur par deffaut
        public PanierViewModel() { }
        #endregion
        //#region constructeur par codeISBN
        //public PanierViewModel(string codeISBN)
        //{
        //    if (MonChoixLivreVM == null)
        //        MonChoixLivreVM = new List<LivreModel>();
        //    MonChoixLivreVM.Add(new LivreModels(codeISBN).ListeLivreM.FirstOrDefault());
        //}
        //#endregion
        #region constructeur par list<codeISBN>
        public PanierViewModel(List<string> mesCodeISBN)
        {
            if (MonChoixLivreVM == null)
               MonChoixLivreVM = new List<LivreModel>();
            foreach (var codeISBN in mesCodeISBN)
            {
                MonChoixLivreVM.Add(new LivreModel(codeISBN));
            }
        }
        #endregion
    }
}