using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public class LivreDTO
    {
        public string CodeISBNDto { get; set; }
        public string NomLivreDto { get; set; }
        public string AuteurDto { get; set; }
        public string EditeurDto { get; set; }
        public string CoverImageDto { get; set; }
        public double PrixDto { get; set; }
        public DescriptionDTO DescriptionDto { get; set; }
        public LivreCategoryDTO LaCategoryDto { get; set; }
    }
}
