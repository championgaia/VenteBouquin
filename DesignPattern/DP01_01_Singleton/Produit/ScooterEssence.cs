using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    public class ScooterEssence : Scooter
    {
        private int Reservoir = 100;
        #region constructeur par déffaut
        public ScooterEssence() { }
        #endregion
        #region constructeur surclass
        public ScooterEssence(string couleur, string modele, int cylindre, int reservoir)
        {
            Couleur = couleur;
            Modele = modele;
            Cylindre = cylindre;
            Reservoir = reservoir;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format("Vehicule de class {0} de couleur {1} de modele {2} avec {3} cylindre et avec reservoir de {4} ",
                GetType().Name, Couleur, Modele, Cylindre, Reservoir);
        }
        #endregion
    }
}
