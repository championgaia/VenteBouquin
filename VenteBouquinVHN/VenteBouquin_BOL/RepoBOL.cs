using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_BOL.Class_BOL;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL
{
    public class RepoBOL
    {
        private LivreCategoryBOLs livreCategories = new LivreCategoryBOLs();
        #region GetLivreCategoryDTOs
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoBol(int codeCategory)
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            LivreCategoryBOLs livreCategoryBOLs = new LivreCategoryBOLs(codeCategory);
            foreach (var item in livreCategoryBOLs.ListeCategory)
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
