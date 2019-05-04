using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA.Class_Control_DATA
{
    internal class GestionCatalogueData
    {
        private VenteBouquinContext context = new VenteBouquinContext();
        #region GetAllLivreCategoryDTOs    GestionCatalogueData
        public List<LivreCategoryDTO> GetAllLivreCategoryDTOs()
        {
            List<LivreCategoryDTO> livreCategoryDTOs = new List<LivreCategoryDTO>();
            foreach (var item in context.LivreCategories
                        .OrderBy(c => c.NomCategory)
                        .ToList())
            {
                livreCategoryDTOs.Add(GetLivreCategory(item.IdCategory));
            }
            return livreCategoryDTOs;
        }
        #endregion
        #region GetLivreCategory par codeCategory    GestionCatalogueData
        public LivreCategoryDTO GetLivreCategory(int codeCategory)
        {
            var category = context.LivreCategories
                        .FirstOrDefault(c => c.IdCategory == codeCategory);
            var categoryDto = new LivreCategoryDTO
            {
                CodeCategoryDto = category.IdCategory,
                NomCategoryDto = category.NomCategory
            };
            return categoryDto;
        }
        #endregion
        #region GetAllLivreDTO  GestionCatalogueData
        public List<LivreDTO> GetAllLivreDTO()
        {
            var listeLivreDTO = new List<LivreDTO>();
            foreach (var item in context.Livres.Distinct().ToList())
            {
                listeLivreDTO.Add(GetLivreParCodeISBNDTO(item.CodeISBN));
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetLivreParCategoryDTO  GestionCatalogueData
        public List<LivreDTO> GetLivreParCategoryDTO(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            foreach (var item in context.Livres
                .Where(c => c.FkLivreCategory == codeCategory)
                .ToList())
            {
                listeLivreDTO.Add(GetLivreParCodeISBNDTO(item.CodeISBN));
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetLivreParCodeISBNDTO  GestionCatalogueData
        public LivreDTO GetLivreParCodeISBNDTO(string codeISBN)
        {
            var livre = context.Livres
                .FirstOrDefault(c => c.CodeISBN == codeISBN);
            var livreDTO = new LivreDTO
            {
                CodeLivreDto = livre.IdLivre,
                CodeISBNDto = livre.CodeISBN,
                NomLivreDto = livre.NomLivre,
                AuteurDto = livre.Auteur,
                EditeurDto = livre.Editeur,
                PrixDto = (double)livre.Prix,
                DescriptionDto = new DescriptionDTO
                {
                    CodeDescriptionDto = livre.Description.IdDescription,
                    CodeISBNDto = livre.Description.CodeISBN,
                    DetailDto = livre.Description.Detail
                },
                LaCategoryDto = GetLivreCategory(livre.FkLivreCategory)
            };
            return livreDTO;
        }
        #endregion
    }
}
