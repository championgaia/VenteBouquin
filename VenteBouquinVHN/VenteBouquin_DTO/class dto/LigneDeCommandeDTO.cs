using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public class LigneDeCommandeDTO
    {
        public int CodeLigneCommandeDto { get; set; }
        public int QuantiteDto { get; set; }
        public CommandeDTO LaCommandeDto { get; set; }
        public LivreDTO LeLivreDto { get; set; }
        public PromotionDTO LaPromoDto { get; set; }
    }
}
