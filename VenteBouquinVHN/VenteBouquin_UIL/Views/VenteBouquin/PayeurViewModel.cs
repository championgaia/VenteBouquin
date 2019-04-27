using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
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
            PayeurVM = new PayeurModel(codePayeur);
        }
        #endregion
        #region constructeur par codeUtilisateur
        public PayeurViewModel(string codeUtilisateur)
        {
            PayeurVM = new PayeurModel(codeUtilisateur);
        }
        #endregion
        #region constructeur par codeUtilisateur
        public PayeurViewModel(string codeUtilisateur, string email)
        {
            PayeurVM = new PayeurModel
            {
                CodeUtilisateurM = codeUtilisateur,
                LoginM = email
            };
        }
        #endregion
        #region CreatePayeur
        public void CreatePayeurViewModel(PayeurViewModel payeurVM)
        {
            payeurVM.PayeurVM.CreatePayeurModel(payeurVM.PayeurVM);
        }
        #endregion
    }
}