using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_03_FabriqueMethod
{
    public class FabriqueDisqueDurATA : FabriqueDisqueDur
    {
        override protected DisqueDur setControleur(String controleur)
        {
            DisqueDur disqueDurATA = null;
            if (controleur == "ATA")
                disqueDurATA = new DisqueDurATA();

            return disqueDurATA;
        }
    }
}
