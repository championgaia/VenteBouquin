using System;
using System.Collections.Generic;

namespace Exo_Morpion.Classes
{
    public class Plateau
    {
        public event EventHandler<EventArgs> CaseJouee;

        public Plateau()
        {
            this.GenererCases();
        }

        public List<Case> Cases { get; private set; }

        public void Reinitialiser()
        {
            foreach (var casePlateau in this.Cases)
                casePlateau.Reinitialiser();
        }

        private void GenererCases()
        {
            this.Cases = new List<Case>();
            for (var ligne = 0; ligne < 3; ligne++)
            {
                for (var colonne = 0; colonne < 3; colonne++)
                {
                    var casePlateau = new Case(ligne, colonne);
                    casePlateau.CaseJouee += this.CasePlateau_CaseJouee;
                    this.Cases.Add(casePlateau);
                }
            }
        }

        private void CasePlateau_CaseJouee(object sender, EventArgs e)
        {
            // A ce niveau (conceptuellement parlant), on n'est pas intéressé par l'événement CaseJouee
            //  Mais ça va intéresser la classe Partie
            //  Or, la classe Partie n'a pas de dépendence sur la classe Case
            //  La solution est donc de créer un événement CaseJouee ici et de le déclencher
            //      quand on intercepte l'événement d'une case
            CaseJouee?.Invoke(sender, EventArgs.Empty);
        }
    }
}
