using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    public class VoitureElectrique : Voiture
    {
        private int Batterie = 10;
        #region constructeur par déffaut
        public VoitureElectrique() { }
        #endregion
        #region constructeur surclass
        public VoitureElectrique(string couleur, string modele, int puissance, string boiteVitesse, int batterie)
        {
            Couleur = couleur;
            Modele = modele;
            Puissance = puissance;
            BoiteVitesse = boiteVitesse;
            Batterie = batterie;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format(
                "Vehicule de class {0} de couleur {1} de modele {2} avec {3} de puissance avec une boite de vitesse {4} et {5} batteries",
                GetType().Name, Couleur, Modele, Puissance, BoiteVitesse, Batterie);
        }
        #endregion
    }
}
