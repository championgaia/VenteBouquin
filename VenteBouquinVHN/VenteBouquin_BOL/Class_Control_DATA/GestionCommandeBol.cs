using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_DATA.Class_Control_BOL
{
    internal class GestionCommandeBol
    {
        private RepoData repo = new RepoData();
        #region GetCommandeDTO par codeCommande     GestionCommandeData
        public CommandeDTO GetCommandeDTO(int codeCommande)
        {
            return repo.GetCommandeDTORepoData(codeCommande);
        }
        #endregion
        #region GetListCommandeDTO par codePayeur
        public List<CommandeDTO> GetListCommandeDTO(int codePayeur)
        {
            return repo.GetListCommandeDTORepoData(codePayeur);
        }
        #endregion
        #region GetAllCommandeDTO       GestionCommandeData
        public List<CommandeDTO> GetAllCommandeDTO()
        {
            return repo.GetAllCommandeDTORepoData();
        }
        #endregion
        #region CreateCommande     GestionCommandeData
        public void CreateCommande(CommandeDTO commandeDto)
        {
            repo.CreateCommande(commandeDto);
        }
        #endregion
    }
}
