
using Refac.Console.PenduReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Nouvelle partie démarrée");
            var client = new PartiePenduClient();

            var p1 = new Partie();
            p1.MotADeviner = "TOTO";
            p1.NbCoupsRestants = 5;
            p1.PatternEnCours = "____";

            //var res = client.VerifierLettre(p1,"T");

            while (p1.Resultat == null)
            {
                System.Console.WriteLine("Entrez une lettre :");
                var lettreInfo = System.Console.ReadKey();
                System.Console.WriteLine("");
                var lettre = lettreInfo.Key.ToString();

                p1 = client.VerifierLettre(p1, lettre);

                System.Console.WriteLine(p1.PatternEnCours);
                System.Console.WriteLine();
            }
            System.Console.WriteLine(p1.Resultat);
            System.Console.ReadKey();

        }



    }
}
