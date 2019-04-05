using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public class PersonneDTO
    {
        public int CodePersonneDto { get; set; }
        public string NomDto { get; set; }
        public string PrenomDto { get; set; }
        public DateTime DateNaissanceDto { get; set; }
        public List<AdresseDTO> ListeAdresseDto { get; set; }
    }
}
