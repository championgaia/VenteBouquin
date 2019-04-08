﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenteBouquin_UIL.Models.VenteBouquinModel;

namespace VenteBouquin_UIL.Views.VenteBouquin
{
    public class LivreCategoryViewModel
    {
        public List<LivreCategoryModel> LivreCategoryVM { get; set; }
        #region constructeur par défault
        public LivreCategoryViewModel()
        {
            
        }
        #endregion
        #region constructeur
        public LivreCategoryViewModel(int codeCategory)
        {
            LivreCategoryModels livreCategoryModels = new LivreCategoryModels(codeCategory);
            LivreCategoryVM = new List<LivreCategoryModel>();
            LivreCategoryVM = livreCategoryModels.ListeCategoryM;
        }
        #endregion
    }
}