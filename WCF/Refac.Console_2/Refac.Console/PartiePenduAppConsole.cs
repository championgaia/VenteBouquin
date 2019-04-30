using Refac.Data;
using Refac.Logique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.ConsoleApp
{
    public class PartiePenduAppConsole
    {
        Partie _p = new Partie();//DONNEES DESCRIPTION
        PartiePendu _partiePendu = new PartiePendu();//METIER
        public PartiePenduAppConsole(string mot,int nbCoups,string pattern)
        {
            _p.MotADeviner = mot;
            _p.NbCoupsRestants = nbCoups;
            _p.PatternEnCours = pattern;
        }
        public void DemarrerPartie()
        {
            Console.WriteLine("Nouvelle partie démarrée");

            while (_p.Resultat == null)
            {
                Console.WriteLine("Entrez une lettre :");
                var lettreInfo = Console.ReadKey();
                Console.WriteLine("");
               var lettre = lettreInfo.Key.ToString();

                _p = _partiePendu.VerifierLettre(_p,lettre);

                Console.WriteLine(_p.PatternEnCours);
                Console.WriteLine();
            }
            Console.WriteLine(_p.Resultat);
            Console.ReadKey();
        }
       
    }
}
