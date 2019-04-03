using DP01_03_FabriqueMethod.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_03_FabriqueMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            FabriqueDisqueDur disqueDurATA = new FabriqueDisqueDurATA();
            disqueDurATA.creerDisqueDur("ATA");

            FabriqueDisqueDur disqueDurSCSI = new FabriqueDisqueDurSCSI();
            disqueDurSCSI.creerDisqueDur("SCSI");

            Console.ReadKey();
        }
    }
}
