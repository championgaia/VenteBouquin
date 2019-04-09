using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.Intranet
{
    public class PayeurViewModel
    {
        public PayeurModel PayeurVM { get; set; }
        #region constructeur par déffault
        public PayeurViewModel()
        {

        }
        #endregion
        #region constructeur par codePayeur
        public PayeurViewModel(int codePayeur)
        {
            PayeurVM = new PayeurModels(codePayeur).ListePayeur.FirstOrDefault();
        }
        #endregion
        #region constructeur par codeUtilisateur
        public PayeurViewModel(string codeUtilisateur)
        {
            PayeurVM = new PayeurModel(codeUtilisateur);
        }
        #endregion
    }
}