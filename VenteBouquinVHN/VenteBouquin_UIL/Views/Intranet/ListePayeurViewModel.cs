using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.Intranet
{
    public class ListePayeurViewModel
    {
        public List<PayeurModel> ListePayeurVM { get; set; }
        #region constructeur par déffaut
        public ListePayeurViewModel()
        {
            ListePayeurVM = new PayeurModels().ListePayeur;
        }
        #endregion
        #region constructeur par codePayeur
        public ListePayeurViewModel(int codePayeur)
        {
            ListePayeurVM.Add(new PayeurModel(codePayeur));
        }
        #endregion
    }
}