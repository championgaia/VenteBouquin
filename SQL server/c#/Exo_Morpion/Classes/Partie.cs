using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Exo_Morpion.Classes
{
    public class Partie : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool estTerminee;
        private Joueur joueurEnCours;
        private string messagePartie;

        public Partie(Jeu jeu, Plateau plateau, Joueur premierJoueur)
        {
            this.Jeu = jeu;
            this.Plateau = plateau;
            this.JoueurEnCours = premierJoueur;

            this.Plateau.Reinitialiser();
            this.Plateau.CaseJouee += this.Plateau_CaseJouee;
        }

        private void Plateau_CaseJouee(object sender, EventArgs e)
        {
            this.MettreAJourEtat();

            if (!this.EstTerminee)
            {
                this.JoueurEnCours = this.Jeu.GetAutreJoueur(this.JoueurEnCours);
            }
        }

        public Jeu Jeu { get; }

        public Plateau Plateau { get; }

        public Joueur JoueurEnCours
        {
            get => this.joueurEnCours;
            set
            {
                if (this.joueurEnCours != value)
                {
                    this.joueurEnCours = value;
                    this.DeclencherEvenementPropertyChanged(nameof(this.JoueurEnCours));

                    if (joueurEnCours != null)
                        MessagePartie = $"Au tour de {joueurEnCours.Nom}";
                }
            }
        }

        public bool EstTerminee
        {
            get => this.estTerminee;
            set
            {
                if (this.estTerminee != value)
                {
                    this.estTerminee = value;
                    this.DeclencherEvenementPropertyChanged(nameof(this.EstTerminee));
                }
            }
        }

        public string MessagePartie
        {
            get => this.messagePartie;
            set
            {
                if (this.messagePartie != value)
                {
                    this.messagePartie = value;
                    this.DeclencherEvenementPropertyChanged(nameof(this.MessagePartie));
                }
            }
        }

        public void MettreAJourEtat()
        {
            // On récupère la liste des cases jouées et on les regroupe par joueur
            var casesJouees = this.Plateau.Cases.Where(x => x.EstJouee);

            // Pour chaque joueur
            foreach (var joueur in this.Jeu.Joueurs)
            {
                // On récupère la liste des cases jouées par ce joueur
                var casesJoueesParJoueur = casesJouees.Where(x => x.JoueePar == joueur);

                // Y a-t-il une ligne avec 3 cases jouées par le joueur ?
                var ligneComplete = casesJoueesParJoueur.GroupBy(x => x.Ligne).Where(x => x.Count() == 3).Select(x => x.ToList()).FirstOrDefault();
                var existeCombinaisonGagnante = this.TraiterCasesSiGagnantes(ligneComplete);

                if (!existeCombinaisonGagnante)
                {
                    // Y a-t-il une colonne avec 3 cases jouées par le joueur ?
                    var colonneComplete = casesJoueesParJoueur.GroupBy(x => x.Colonne).Where(x => x.Count() == 3).Select(x => x.ToList()).FirstOrDefault();
                    existeCombinaisonGagnante = this.TraiterCasesSiGagnantes(colonneComplete);
                }

                if (!existeCombinaisonGagnante)
                {
                    var diagonaleHautGaucheBasDroitComplete = casesJoueesParJoueur
                        .Where(x => (x.Ligne == 0 && x.Colonne==0)
                                        || (x.Ligne == 1 && x.Colonne == 1)
                                        || (x.Ligne == 2 && x.Colonne == 2));
                    existeCombinaisonGagnante = this.TraiterCasesSiGagnantes(diagonaleHautGaucheBasDroitComplete);
                }

                if (!existeCombinaisonGagnante)
                {
                    var diagonaleBasGaucheHautDroit = casesJoueesParJoueur
                        .Where(x => (x.Ligne == 2 && x.Colonne==0)
                                        || (x.Ligne == 1 && x.Colonne == 1)
                                        || (x.Ligne == 0 && x.Colonne == 2));
                    existeCombinaisonGagnante = this.TraiterCasesSiGagnantes(diagonaleBasGaucheHautDroit);
                }

                if (existeCombinaisonGagnante)
                {
                    this.DesignerVainqueur(joueur);
                    this.TerminerPartie(joueur);
                    break;
                }
            }

            // Si toutes les cases sont jouées, alors la partie est terminée
            if (casesJouees.Count() == Plateau.Cases.Count())
                this.TerminerPartie(null);
        }

        private bool TraiterCasesSiGagnantes(IEnumerable<Case> cases)
        {
            // On ne modifie l'état des cases que s'il y a 3 cases passées en paramètre
            if (cases == null || cases.Count() < 3) return false;

            foreach (var casePlateau in cases)
            {
                casePlateau.Etat = EtatCase.Gagnee;
            }

            return true;
        }

        private void DesignerVainqueur(Joueur joueur)
        {
            // On met à jour les "stats" des joueurs
            joueur.NombrePartiesGagnees++;
            this.Jeu.GetAutreJoueur(joueur).NombrePartiesPerdues++;
        }

        private void TerminerPartie(Joueur joueurGagnant)
        {
            this.JoueurEnCours = null;
            this.EstTerminee = true;

            // On informe du résultat
            MessagePartie = joueurGagnant != null ? $"{joueurGagnant.Nom} a gagné !" : "Match nul";

            // Important: ne pas oublier de se désabonner de l'événement CaseJouee !
            this.Plateau.CaseJouee -= this.Plateau_CaseJouee;
        }

        private void DeclencherEvenementPropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
