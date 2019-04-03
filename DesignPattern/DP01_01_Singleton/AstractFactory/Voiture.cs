using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    public abstract class Voiture : Vehicule
    {
        protected int Puissance = 400;
        protected string BoiteVitesse = "auto";
    }
}
