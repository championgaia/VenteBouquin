using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDto.ClassDTO
{
    public class PersonneDTO
    {
        public int CodePersonneDto { get; set; }
        public string NomDto { get; set; }
        public string PrenomDto { get; set; }
        public string DateNaissanceDto { get; set; }
        
        public AdresseDTO AdresseDto { get; set; }
    }
}
