using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public class CommandeDTO
    {
        public int CodeCommandeDto { get; set; }
        public double PrixTotalDto { get; set; }
        public PayeurDTO LePayeurDto { get; set; }
        public List<LigneDeCommandeDTO> LesLignesDto { get; set; }
    }
}
