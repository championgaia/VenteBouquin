using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_BOL;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class LivreCategoryModel
    {
        public int CodeCategoryM { get; set; }
        public string NomCategoryM { get; set; }
        #region constructeur par défault
        public LivreCategoryModel()
        {

        }
        #endregion
    }
    public class LivreCategoryModels
    {
        public List<LivreCategoryModel> ListeCategoryM { get; set; }
        private RepoBOL repo = new RepoBOL();
        #region Constructeur par deffault
        public LivreCategoryModels()
        {

        }
        #endregion
        #region Constructeur
        public LivreCategoryModels(int codeCategory)
        {
            ListeCategoryM = new List<LivreCategoryModel>();
            //besoin repo
            foreach (var item in repo.GetLivreCategoryDTOsRepoBol(codeCategory))
            {
                ListeCategoryM.Add(new LivreCategoryModel
                {
                    CodeCategoryM = item.CodeCategoryDto,
                    NomCategoryM = item.NomCategoryDto
                });
            }
        }
        #endregion
    }
}