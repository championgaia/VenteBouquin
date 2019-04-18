using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Exo_Morpion.Classes
{
    public class Jeu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Partie partieEnCours;

        public Jeu()
        {
            Plateau = new Plateau();
            Joueurs = new List<Joueur>
            {
                new Joueur(1, "Joueur 1", "O"),
                new Joueur(2, "Joueur 2", "X"),
            };
            Parties = new List<Partie>();
        }

        public Plateau Plateau { get; }

        public List<Partie> Parties { get; }

        public List<Joueur> Joueurs { get; }

        public Partie PartieEnCours
        {
            get { return partieEnCours; }
            set
            {
                if (partieEnCours != value)
                {
                    partieEnCours = value;
                    DeclencherEvenementPropertyChanged(nameof(PartieEnCours));
                }
            }
        }

        public void NouvellePartie()
        {
            PartieEnCours = new Partie(this, Plateau, Joueurs.First());
            Parties.Add(PartieEnCours);

            Plateau.Reinitialiser();
        }

        internal Joueur GetAutreJoueur(Joueur joueur)
        {
            // Si le joueur passé en paramètre a pour ordre 1, on renvoie le joueur avec l'ordre 2
            return Joueurs
               .Single(x => x.Ordre == (joueur.Ordre == 1 ? 2 : 1));
        }

        private void DeclencherEvenementPropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
