using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_03_FabriqueMethod
{
    public abstract class FabriqueDisqueDur
    {
        public DisqueDur creerDisqueDur(String controleur)
        {
            DisqueDur disqueDur;

            disqueDur = setControleur(controleur);
            disqueDur.setNbTours("7200");
            disqueDur.Tester();
            disqueDur.Finaliser();

            return disqueDur;
        }

        protected abstract DisqueDur setControleur(String typeControleur);
    }
}
