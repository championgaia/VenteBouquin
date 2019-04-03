using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_03_FabriqueMethod.Classes
{
    public class DisqueDurSCSI : DisqueDur
    {
        public DisqueDurSCSI()
        {
            Console.WriteLine("Disque Dur SCSI cree");
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
            Console.WriteLine("Disque dur SCSI operationnel");
        }
    }
}
