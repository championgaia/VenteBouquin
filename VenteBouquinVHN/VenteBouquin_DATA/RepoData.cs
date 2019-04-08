﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA.Class_DATA;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA
{
    public class RepoData
    {
        private LivreCategoryDatas livreCategories = new LivreCategoryDatas();
        private LivreDatas livres = new LivreDatas();
        private PayeurDatas payeurs = new PayeurDatas();
        #region GetLivreCategoryDTOs
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoData(int codeCategory)
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            LivreCategoryDatas livreCategoryDatas = new LivreCategoryDatas(codeCategory);
            foreach (var item in livreCategoryDatas.ListeCategory)
            {
                livreCategoryDTOs.Add(new LivreCategoryDTO
                {
                    CodeCategoryDto = item.CodeCategory,
                    NomCategoryDto = item.NomCategory
                });
            }
            return livreCategoryDTOs;
        }
        #endregion
    }
}
