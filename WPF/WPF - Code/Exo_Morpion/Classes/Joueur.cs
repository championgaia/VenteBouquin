using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Morpion.Classes
{
    public class Joueur
    {
        public Joueur(int ordre, string symbole)
        {
            Ordre = ordre;
            Symbole = symbole;
        }

        public int Ordre { get; }

        public string Symbole { get; }

        public string Nom { get; set; }

        public int NombrePartiesGagnees { get; set; }

        public int NombrePartiesPerdues { get; set; }

        public void JouerCase(Case casePlateau)
        {
            casePlateau.JoueePar = this;
        }
    }
}
