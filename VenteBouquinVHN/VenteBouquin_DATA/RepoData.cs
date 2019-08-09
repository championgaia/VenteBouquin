using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DATA.Class_Control_DATA;
using VenteBouquin_DATA.Class_DATA;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA
{
    public class RepoData : IRepositoryData
    {
        private GestionCatalogueData gestionCatalogue = new GestionCatalogueData();
        private GestionCommandeData gestionCommande = new GestionCommandeData();
        private GestionUtilisateurData gestionUtilisateur = new GestionUtilisateurData();
        #region GetLivreCategoryDTOsRepoData
        #region GetLivreCategoryDTOsRepoData all category
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoData()
        {
            return gestionCatalogue.GetAllLivreCategory();
        }
        #endregion
        #region GetLivreCategoryDTOsRepoData par codeCategory
        public LivreCategoryDTO GetLivreCategoryDTOsRepoData(int codeCategory)
        {
            return gestionCatalogue.GetLivreCategory(codeCategory);
        }
        #endregion
        #endregion
        #region Livre repoData
        #region GetAllLivreDTORepoData
        public List<LivreDTO> GetAllLivreDTORepoData()
        {
            return gestionCatalogue.GetAllLivreDTO();
        }
        #endregion
        #region GetLivreParCategoryDTORepoData
        public List<LivreDTO> GetLivreParCategoryDTORepoData(int codeCategory)
        {
            return gestionCatalogue.GetLivreParCategoryDTO(codeCategory);
        }
        #endregion
        #region GetLivreParCodeISBNDTORepoData
        public LivreDTO GetLivreParCodeISBNDTORepoData(string codeISBN)
        {
            return gestionCatalogue.GetLivreParCodeISBNDTO(codeISBN);
        }
        #endregion
        #endregion
        #region Payeur
        #region GetPayeurDTORepoData par codePayeur
        public PayeurDTO GetPayeurDTORepoData(int codePayeur)
        {
            return gestionUtilisateur.GetPayeurDTO(codePayeur);
        }
        #endregion
        #region GetPayeurDTORepoData par codeUtilisateur
        public PayeurDTO GetPayeurDTORepoData(string codeUtilisateur)
        {
            return gestionUtilisateur.GetPayeurDTO(codeUtilisateur);
        }
        #endregion
        #region GetAllPayeurDTORepoData
        public List<PayeurDTO> GetAllPayeurDTORepoData()
        {
            return gestionUtilisateur.GetAllPayeurDTO();
        }
        #endregion
        #region CreatePayeurRepoData
        public void CreatePayeurRepoData(PayeurDTO payeurDto)
        {
            gestionUtilisateur.CreatePayeur(payeurDto);
        }
        #endregion
        #endregion
        #region GetCommandeDTORepoData
        #region GetCommandeDTORepoData par codeCommande
        public CommandeDTO GetCommandeDTORepoData(int codeCommande)
        {
            return gestionCommande.GetCommandeDTO(codeCommande);
        }
        #endregion
        #region GetListCommandeDTORepoData par codePayeur
        public List<CommandeDTO> GetListCommandeDTORepoData(int codePayeur)
        {
            return gestionCommande.GetListCommandeDTO(codePayeur);
        }
        #endregion
        #region GetAllCommandeDTORepoData
        public List<CommandeDTO> GetAllCommandeDTORepoData()
        {
            return gestionCommande.GetAllCommandeDTO();
        }
        #endregion
        #region CreateCommande repoData
        public void CreateCommande(CommandeDTO commandeDto)
        {
            gestionCommande.CreateCommande(commandeDto);
        }
        #endregion
        #endregion
    }
}
