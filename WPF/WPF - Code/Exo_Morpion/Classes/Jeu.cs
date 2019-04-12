using System.Collections.Generic;
using System.Linq;

namespace Exo_Morpion.Classes
{
    public class Jeu
    {
        public Jeu()
        {
            Plateau = new Plateau();
            Joueurs = new List<Joueur>
            {
                new Joueur(1, "O"),
                new Joueur(2, "X"),
            };
            Parties = new List<Partie>();
        }

        public Plateau Plateau { get; }

        public List<Partie> Parties { get; }

        public List<Joueur> Joueurs { get; }

        public Partie PartieEnCours { get; set; }

        public void NouvellePartie()
        {
            PartieEnCours = new Partie(this, Joueurs.First());
            Parties.Add(PartieEnCours);
        }
    }
}
