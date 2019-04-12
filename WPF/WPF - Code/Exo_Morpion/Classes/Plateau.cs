using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Morpion.Classes
{
    public class Plateau
    {
        public event EventHandler<EventArgs> CaseJouee;

        public Plateau()
        {
            GenererCases();
        }

        public List<Case> Cases { get; private set; }

        public void Reinitialiser()
        {
            foreach (var casePlateau in Cases)
                casePlateau.Reinitialiser();
        }

        private void GenererCases()
        {
            Cases = new List<Case>();
            for (var ligne = 1; ligne <= 3; ligne++)
                for (var colonne = 1; colonne <= 3; colonne++)
                {
                    var casePlateau = new Case(ligne, colonne);
                    casePlateau.CaseJouee += CasePlateau_CaseJouee;
                    Cases.Add(casePlateau);
                }
        }

        private void CasePlateau_CaseJouee(object sender, EventArgs e)
        {
            // On transfère l'événement plus haut
            CaseJouee?.Invoke(sender, EventArgs.Empty);
        }
    }
}
