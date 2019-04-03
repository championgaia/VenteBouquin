using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_03_FabriqueMethod

{
    public class DisqueDurATA : DisqueDur
    {
        public DisqueDurATA()
        {
            Console.WriteLine("Disque Dur ATA cree");
        }

        public override void setNbTours(String nombre)
        {
            Console.WriteLine("Nb tours : " + nombre + " tours");
        }

        public override void Tester()
        {
            Console.WriteLine("Tests en cours..");
        }

        public override void Finaliser()
        {
            Console.WriteLine("Disque dur ATA operationnel");
        }
    }
}
