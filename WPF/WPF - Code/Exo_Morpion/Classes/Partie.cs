using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Morpion.Classes
{
    public class Partie
    {
        public Partie(Jeu jeu, Joueur premierJoueur)
        {
            Jeu = jeu;
            JoueurEnCours = premierJoueur;

            Jeu.Plateau.CaseJouee += Plateau_CaseJouee;
        }

        private void Plateau_CaseJouee(object sender, EventArgs e)
        {
            
        }

        public Jeu Jeu { get; }

        public Joueur JoueurEnCours { get; set; }

        public void MettreAJourEtat()
        {

        }
    }
}
