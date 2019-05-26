using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public interface IGestionUtilisateur
    {
        PayeurDTO GetPayeurDTO(int codePayeur);
        PayeurDTO GetPayeurDTO(string codeUtilisateur);
        List<PayeurDTO> GetAllPayeurDTO();
        void CreatePayeur(PayeurDTO payeurDto);
    }
}
