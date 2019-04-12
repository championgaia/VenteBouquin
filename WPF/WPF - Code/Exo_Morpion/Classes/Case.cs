using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Morpion.Classes
{
    public class Case : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> CaseJouee;

        private Joueur joueePar;

        public Case(int ligne, int colonne)
        {
            Ligne = ligne;
            Colonne = colonne;
        }

        public int Ligne { get; }

        public int Colonne { get; }

        public Joueur JoueePar
        {
            get { return joueePar; }
            set
            {
                // Ne pas continuer si la case est déjà jouée
                if (EstJouee) return;

                if (joueePar != null)
                {
                    joueePar = value;
                    RaisePropertyChanged(nameof(JoueePar));
                    RaisePropertyChanged(nameof(EstJouee));
                }

                if (joueePar != null)
                    CaseJouee?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool EstJouee
        {
            get { return JoueePar != null; }
        }

        public void Reinitialiser()
        {
            JoueePar = null;
        }

        private void RaisePropertyChanged(string nomPropriete)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nomPropriete));
        }
    }
}
