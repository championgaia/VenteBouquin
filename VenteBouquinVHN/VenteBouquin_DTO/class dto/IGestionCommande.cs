using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public interface IGestionCommande
    {
        CommandeDTO GetCommandeDTO(int codeCommande);
        List<CommandeDTO> GetListCommandeDTO(int codePayeur);
        List<CommandeDTO> GetAllCommandeDTO();
        void CreateCommande(CommandeDTO commandeDto);
    }
}
