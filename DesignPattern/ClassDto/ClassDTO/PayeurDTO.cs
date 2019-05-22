using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDto.ClassDTO
{
    public class PayeurDTO
    {
        public int CodePayeurDto { get; set; }
        public string CodeUtilisateurDto { get; set; }
        public string LoginDto { get; set; }
        public string PasswordDto { get; set; }
        public string RoleDto { get; set; }
        public PersonneDTO PersonneDto { get; set; }
    }
}
