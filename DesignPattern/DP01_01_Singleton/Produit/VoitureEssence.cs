using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    public class VoitureEssence : Voiture
    {
        private int Reservoir = 100;
        #region constructeur par déffaut
        public VoitureEssence() { }
        #endregion
        #region constructeur surclass
        public VoitureEssence(string couleur, string modele, int puissance, string boiteVitesse, int reservoir)
        {
            Couleur = couleur;
            Modele = modele;
            Puissance = puissance;
            BoiteVitesse = boiteVitesse;
            Reservoir = reservoir;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format(
                "Vehicule de class {0} de couleur {1} de modele {2} avec {3} de puissance avec une boite de vitesse {4} et une reservoir de {5} ",
                GetType().Name, Couleur, Modele, Puissance, BoiteVitesse, Reservoir);
        }
        #endregion
    }
}
