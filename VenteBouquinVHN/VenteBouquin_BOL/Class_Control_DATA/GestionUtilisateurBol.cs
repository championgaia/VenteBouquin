using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA.Class_Control_BOL
{
    internal class GestionUtilisateurBol: IGestionUtilisateur
    {
        private IRepositoryData repo;
        public GestionUtilisateurBol(IRepositoryData repoData)
        {
            repo = repoData;
        }
        #region GetPayeurDTO par codePayeur     GestionUtilisateurData
        public PayeurDTO GetPayeurDTO(int codePayeur)
        {
            return repo.GetPayeurDTORepoData(codePayeur);
        }
        #endregion
        #region GetPayeurDTO par codeUtilisateur     GestionUtilisateurData
        public PayeurDTO GetPayeurDTO(string codeUtilisateur)
        {
            return repo.GetPayeurDTORepoData(codeUtilisateur);
        }
        #endregion
        #region GetAllPayeurDTO     GestionUtilisateurData
        public List<PayeurDTO> GetAllPayeurDTO()
        {
            return repo.GetAllPayeurDTORepoData();
        }
        #endregion
        #region CreatePayeur    GestionUtilisateurData
        public void CreatePayeur(PayeurDTO payeurDto)
        {
            repo.CreatePayeurRepoData(payeurDto);
        }
        #endregion
    }
}
