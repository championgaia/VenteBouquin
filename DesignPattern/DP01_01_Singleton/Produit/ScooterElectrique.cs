using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    public class ScooterElectrique : Scooter
    {
        private int Batterie = 10;
        #region constructeur par déffaut
        public ScooterElectrique() {}
        #endregion
        #region constructeur surclass
        public ScooterElectrique(string couleur, string modele, int cylindre, int batterie)
        {
            Couleur = couleur;
            Modele = modele;
            Cylindre = cylindre;
            Batterie = batterie;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format("Vehicule de class {0} de couleur {1} de modele {2} avec {3} cylindre et {4} batteries", 
                GetType().Name, Couleur, Modele, Cylindre, Batterie);
        }
        #endregion
    }
}
