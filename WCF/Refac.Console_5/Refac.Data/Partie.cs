using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.Data
{
    public class Partie
    {
        public Partie(string mot, int nbr)
        {
            MotADeviner = mot;
            NbCoupsRestants = nbr;
            if(mot != null)
                PatternEnCours = string.Concat(mot.Select(c => '_'));
        }
        public Partie()
        {
            var g = new GenerateurDeMotADeviner();
            MotADeviner = g.GetMot();
            if (MotADeviner != null)
                PatternEnCours = string.Concat(MotADeviner.Select(c => '_'));
        }

        public int Id { get; set; }
        public string MotADeviner { get; private set; }
        public string PatternEnCours { get; set; }
        public int NbCoupsRestants { get; set; }
        public string Resultat { get; set; }
    }
}
