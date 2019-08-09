using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public interface IRepositoryBol
    {
        List<LivreCategoryDTO> GetLivreCategoryDTOsRepoBol();
        List<LivreDTO> GetAllLivreDTORepoData();
        List<LivreDTO> GetLivreParCategoryDTORepoBol(int codeCategory);
        LivreDTO GetLivreParCodeISBNDTORepoBol(string codeISBN);
        List<PayeurDTO> GetAllPayeurDTORepoData();
        PayeurDTO GetPayeurDTORepoBol(int codePayeur);
        PayeurDTO GetPayeurDTORepoBol(string codeUtilisateur);
        void CreatePayeurRepoBol(PayeurDTO payeurDto);
        CommandeDTO GetCommandeDTORepoBol(int codeCommande);
        List<CommandeDTO> GetListCommandeDTORepoBol(int codePayeur);
        List<CommandeDTO> GetAllCommandeDTORepoData();
        void CreateCommande(CommandeDTO commandeDto);
    }
}
