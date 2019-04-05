using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DTO.class_dto
{
    public class PayeurDTO
    {
        public int CodePayeurDto { get; set; }
        public string CodeUtilisateurDto { get; set; }
        public PersonneDTO PersonneDto { get; set; }
    }
}
