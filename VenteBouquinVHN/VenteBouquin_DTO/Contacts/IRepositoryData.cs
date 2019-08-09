using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public interface IRepositoryData
    {
        List<LivreCategoryDTO> GetLivreCategoryDTOsRepoData();
        LivreCategoryDTO GetLivreCategoryDTOsRepoData(int codeCategory);
        List<LivreDTO> GetAllLivreDTORepoData();
        List<LivreDTO> GetLivreParCategoryDTORepoData(int codeCategory);
        LivreDTO GetLivreParCodeISBNDTORepoData(string codeISBN);
        PayeurDTO GetPayeurDTORepoData(int codePayeur);
        PayeurDTO GetPayeurDTORepoData(string codeUtilisateur);
        List<PayeurDTO> GetAllPayeurDTORepoData();
        void CreatePayeurRepoData(PayeurDTO payeurDto);
        CommandeDTO GetCommandeDTORepoData(int codeCommande);
        List<CommandeDTO> GetListCommandeDTORepoData(int codePayeur);
        List<CommandeDTO> GetAllCommandeDTORepoData();
        void CreateCommande(CommandeDTO commandeDto);
    }
}
