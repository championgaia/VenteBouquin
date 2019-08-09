using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_BOL.Class_BOL;
using VenteBouquin_DATA;
using VenteBouquin_DATA.Class_Control_BOL;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL
{
    public class RepoBOL : IRepositoryBol
    {
        private GestionCatalogueBol gestionCatalogue = new GestionCatalogueBol(new RepoData());
        private GestionCommandeBol gestionCommande = new GestionCommandeBol(new RepoData());
        private GestionUtilisateurBol gestionUtilisateur = new GestionUtilisateurBol(new RepoData());
        #region GetLivreCategoryDTOs
        public List<LivreCategoryDTO> GetLivreCategoryDTOsRepoBol()
        {
            return gestionCatalogue.GetAllLivreCategory();
        }
        #endregion
        #region Livre  RepoBOL
        #region GetAllLivreDTORepoData
        public List<LivreDTO> GetAllLivreDTORepoData()
        {
            return gestionCatalogue.GetAllLivreDTO();
        }
        #endregion
        #region GetLivreParCategoryDTORepoBol
        public List<LivreDTO> GetLivreParCategoryDTORepoBol(int codeCategory)
        {
            return gestionCatalogue.GetLivreParCategoryDTO(codeCategory);
        }
        #endregion
        #region GetLivreParCodeISBNDTORepoBol
        public LivreDTO GetLivreParCodeISBNDTORepoBol(string codeISBN)
        {
            return gestionCatalogue.GetLivreParCodeISBNDTO(codeISBN);
        }
        #endregion
        #endregion
        #region Payeur  RepoBOL
        #region GetAllPayeurDTORepoData
        public List<PayeurDTO> GetAllPayeurDTORepoData()
        {
            return gestionUtilisateur.GetAllPayeurDTO();
        }
        #endregion
        #region GetPayeurDTORepoBol par codePayeur
        public PayeurDTO GetPayeurDTORepoBol(int codePayeur)
        {
            return gestionUtilisateur.GetPayeurDTO(codePayeur);
        }
        #endregion
        #region GetPayeurDTORepoBol par codeUtilisateur
        public PayeurDTO GetPayeurDTORepoBol(string codeUtilisateur)
        {
            return gestionUtilisateur.GetPayeurDTO(codeUtilisateur);
        }
        #endregion
        #region CreatePayeurRepoBol
        public void CreatePayeurRepoBol(PayeurDTO payeurDto)
        {
            gestionUtilisateur.CreatePayeur(payeurDto);
        }
        #endregion
        #endregion
        #region Commande RepoBOL
        #region GetCommandeDTORepoBol par codeCommande
        public CommandeDTO GetCommandeDTORepoBol(int codeCommande)
        {
            return gestionCommande.GetCommandeDTO(codeCommande);
        }
        #endregion
        #region GetListCommandeDTORepoBol par codePayeur
        public List<CommandeDTO> GetListCommandeDTORepoBol(int codePayeur)
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
        #region CreateCommande RepoBOL
        public void CreateCommande(CommandeDTO commandeDto)
        {
            gestionCommande.CreateCommande(commandeDto);
        }
        #endregion
        #endregion
    }
}
