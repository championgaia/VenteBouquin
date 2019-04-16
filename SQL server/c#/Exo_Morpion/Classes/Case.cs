using System;
using System.ComponentModel;

namespace Exo_Morpion.Classes
{
    public class Case : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> CaseJouee;

        private Joueur joueePar;
        private EtatCase etatCase;

        public Case(int ligne, int colonne)
        {
            this.Ligne = ligne;
            this.Colonne = colonne;
        }

        public int Ligne { get; }

        public int Colonne { get; }

        public Joueur JoueePar
        {
            get => this.joueePar;
            set
            {
                // On ne peut pas définir un joueur si la case est déjà jouée
                if (value != null && this.EstJouee) return;

                if (this.joueePar != value)
                {
                    this.joueePar = value;
                    this.DeclencherEvenementPropertyChanged(nameof(this.JoueePar));
                    this.DeclencherEvenementPropertyChanged(nameof(this.EstJouee));
                }

                if (this.joueePar != null)
                {
                    this.Etat = EtatCase.Jouee;
                    CaseJouee?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public EtatCase Etat
        {
            get => this.etatCase;
            set
            {
                if (this.etatCase != value)
                {
                    this.etatCase = value;
                    this.DeclencherEvenementPropertyChanged(nameof(this.Etat));
                }
            }
        }

        public bool EstJouee => this.JoueePar != null;

        public void Reinitialiser()
        {
            this.JoueePar = null;
            this.Etat = EtatCase.NonJouee;
        }

        private void DeclencherEvenementPropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
