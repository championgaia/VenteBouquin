using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.ConsoleApp
{
    public class Partie
    {
        public int Id { get; set; }
        public string MotADeviner { get; set; }
        public string PatternEnCours { get; set; }
        public int NbCoupsRestants { get; set; }
        public string Resultat { get; set; }
        public void DemarrerPartie()
        {
            Console.WriteLine("Nouvelle partie démarrée");
            while (NbCoupsRestants >0 && !IsPartieGagnee())
            {
                Console.WriteLine("Entrez une lettre :");
                var lettreInfo = Console.ReadKey();
                Console.WriteLine("");
               var lettre = lettreInfo.Key.ToString();

                if(MotADeviner.Contains(lettre))
                {
                    // detecter les occurences de la lettre et mettre à jour le Pattern
                    var positionsTrouvées = new List<int>();
                    for (int i = 0; i < MotADeviner.Length; i++)
                    {
                        if (MotADeviner[i] == lettre[0])
                            positionsTrouvées.Add(i);
                    }
                    //modifier le pattern 
                    char[] patternencours = PatternEnCours.ToCharArray();
                    foreach (var positionIndex in positionsTrouvées)
                    {
                        patternencours[positionIndex] = MotADeviner[positionIndex];
                    }
                    PatternEnCours = new string(patternencours);
                }
                else
                {
                    NbCoupsRestants--;
                }
                Console.WriteLine(PatternEnCours);
                Console.WriteLine();
            }
            if (IsPartiePerdue())
                Console.WriteLine("Partie Perdue");
            if (IsPartieGagnee())
                Console.WriteLine("Partie Gagnée");
        }
        public bool IsPartieGagnee()
        {
            return PatternEnCours == MotADeviner;
        }
        public bool IsPartiePerdue()
        {
            return NbCoupsRestants <=0;
        }
    }
}
