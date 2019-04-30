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

            var p = new Partie();
            p.MotADeviner = "TELEPHONE";
            p.NbCoupsRestants = 10;
            p.PatternEnCours = "_________";

            p.DemarrerPartie();


        }
    }
}
