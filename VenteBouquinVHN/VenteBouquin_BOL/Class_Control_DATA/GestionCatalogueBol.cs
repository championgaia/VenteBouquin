using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA.Class_Control_BOL
{
    internal class GestionCatalogueBol: IGestionCatalogue
    {
        private RepoData repo = new RepoData();
        #region GetAllLivreCategory    GestionCatalogueData
        public List<LivreCategoryDTO> GetAllLivreCategory()
        {
            return repo.GetLivreCategoryDTOsRepoData();
        }
        #endregion
        #region GetLivreCategory par codeCategory    GestionCatalogueData
        public LivreCategoryDTO GetLivreCategory(int codeCategory)
        {
            return repo.GetLivreCategoryDTOsRepoData(codeCategory);
        }
        #endregion
        #region GetAllLivreDTO  GestionCatalogueData
        public List<LivreDTO> GetAllLivreDTO()
        {
            return repo.GetAllLivreDTORepoData();
        }
        #endregion
        #region GetLivreParCategoryDTO  GestionCatalogueData
        public List<LivreDTO> GetLivreParCategoryDTO(int codeCategory)
        {
            return repo.GetLivreParCategoryDTORepoData(codeCategory);
        }
        #endregion
        #region GetLivreParCodeISBNDTO  GestionCatalogueData
        public LivreDTO GetLivreParCodeISBNDTO(string codeISBN)
        {
            return repo.GetLivreParCodeISBNDTORepoData(codeISBN);
        }
        #endregion
    }
}
