using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDto.ClassDTO
{
    public class LivreDTO
    {
        public int CodeLivreDto { get; set; }
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
