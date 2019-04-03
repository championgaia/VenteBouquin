using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_03_FabriqueMethod.Classes
{
    public class FabriqueDisqueDurSCSI : FabriqueDisqueDur
    {
        override protected DisqueDur setControleur(String controleur)
        {
            DisqueDur disqueDurSCSI = null;
            if (controleur == "SCSI")
                disqueDurSCSI = new DisqueDurSCSI();

            return disqueDurSCSI;
        }
    }
}
