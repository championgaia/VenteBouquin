using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.Data
{
    public class Partie
    {
        public int Id { get; set; }
        public string MotADeviner { get; set; }
        public string PatternEnCours { get; set; }
        public int NbCoupsRestants { get; set; }
        public string Resultat { get; set; }
    }
}
