using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
{
    public class LivreViewModel
    {
        public LivreModel LivreVM { get; set; }
        #region constructeur par déffaut
        public LivreViewModel()
        {

        }
        #endregion
        #region constructeur par codeISBN
        public LivreViewModel(string codeISBN)
        {
            LivreVM = new LivreModel(codeISBN);
        }
        #endregion
    }
}