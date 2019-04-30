
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
            //var p = new PartiePenduAppConsole("TELEPHONE",10, "_________");
            //p.DemarrerPartie();

            var client = new PartiePenduClient();

            var p1 = new Partie();
            p1.MotADeviner = "TOTO";
            p1.NbCoupsRestants = 5;
            p1.PatternEnCours = "____";

            var res = client.VerifierLettre(p1,"T");

        }



    }
}
