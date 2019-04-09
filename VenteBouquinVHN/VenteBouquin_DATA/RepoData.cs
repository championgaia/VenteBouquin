using System;
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
        private LivreDatas livres;
        private PayeurDatas payeurs;
        #region GetLivreCategoryDTOsRepoData
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
        #region GetLivreParCategoryDTORepoData
        public List<LivreDTO> GetLivreParCategoryDTORepoData(int codeCategory)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreDatas(codeCategory);
            foreach (var item in livres.ListeLivre)
            {
                listeLivreDTO.Add(new LivreDTO {
                    CodeISBNDto = item.CodeISBN,
                    NomLivreDto = item.NomLivre,
                    AuteurDto = item.Auteur,
                    EditeurDto = item.Editeur,
                    CoverImageDto = item.CoverImage,
                    PrixDto = item.Prix,
                    DescriptionDto = new DescriptionDTO
                    {
                        CodeDescriptionDto = item.Description.CodeDescription,
                        CodeISBNDto = item.Description.CodeISBN,
                        DetailDto = item.Description.Detail
                    },
                    LaCategoryDto = new LivreCategoryDTO
                    {
                        CodeCategoryDto = item.LaCategory.CodeCategory,
                        NomCategoryDto = item.LaCategory.NomCategory
                    }
                });
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetLivreParCodeISBNDTORepoData
        public List<LivreDTO> GetLivreParCodeISBNDTORepoData(string codeISBN)
        {
            var listeLivreDTO = new List<LivreDTO>();
            livres = new LivreDatas(codeISBN);
            foreach (var item in livres.ListeLivre)
            {
                listeLivreDTO.Add(new LivreDTO
                {
                    CodeISBNDto = item.CodeISBN,
                    NomLivreDto = item.NomLivre,
                    AuteurDto = item.Auteur,
                    EditeurDto = item.Editeur,
                    PrixDto = item.Prix,
                    DescriptionDto = new DescriptionDTO
                    {
                        CodeDescriptionDto = item.Description.CodeDescription,
                        CodeISBNDto = item.Description.CodeISBN,
                        DetailDto = item.Description.Detail
                    },
                    LaCategoryDto = new LivreCategoryDTO
                    {
                        CodeCategoryDto = item.LaCategory.CodeCategory,
                        NomCategoryDto = item.LaCategory.NomCategory
                    }
                });
            }
            return listeLivreDTO;
        }
        #endregion
        #region GetPayeurDTORepoData
        public List<PayeurDTO> GetPayeurDTORepoData(string codePayeur)
        {
            List<PayeurDTO> monListePayeurDto = new List<PayeurDTO>();
            payeurs = new PayeurDatas(codePayeur);
            foreach (var item in payeurs.ListePayeur)
            {
                monListePayeurDto.Add(new PayeurDTO()
                {
                    CodePayeurDto = item.CodePayeur,
                    CodeUtilisateurDto = item.CodeUtilisateur,
                    PersonneDto = new PersonneDTO
                    {
                        CodePersonneDto = item.Personne.CodePersonne,
                        NomDto = item.Personne.Nom,
                        PrenomDto = item.Personne.Prenom,
                        DateNaissanceDto = item.Personne.DateNaissance
                    }
                });
            }
            //manque liste d'adresse
            return null;
        }
        #endregion
    }
}
