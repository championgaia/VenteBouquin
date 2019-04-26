using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
{
    public class CreateCommandeViewModel
    {
        public CommandeModel LaCommandeVM { get; set; }
        #region Constructeur
        #region constructeur par deffaut
        public CreateCommandeViewModel() { }
        #endregion
        #region constructeur par mesCodeISBN, codePayer
        public CreateCommandeViewModel(List<string> mesCodeISBN, string codeUtilisateur)
        {
            LaCommandeVM = new CommandeModel
            {
                LePayeurM = new PayeurModel(codeUtilisateur),
                LesLignesM = new List<LigneDeCommandeModel>()
            };
            foreach (var codeISBN in mesCodeISBN)
            {
                LaCommandeVM.LesLignesM.Add(new LigneDeCommandeModel
                {
                    LeLivreM = new LivreModel(codeISBN)
                });
            }
        }
        #endregion
        #endregion
        #region CreateCommande
        public void CreateCommande(CreateCommandeViewModel createCommande)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}