using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_02_Builder.TourComputer
{
    public class Tour
    {
        private string alimentation = "";
        private string carteMere = "";
        private string boitier = "";
        private string disqueDur = "";
        private string memoireRAM = "";
        private string carteGraphique = "";
        private string processeur = "";
        private string carteSon = "";

        public void setAlimentation(string alimentation) { this.alimentation = alimentation; }
        public void setCarteMere(string carteMere) { this.carteMere = carteMere; }
        public void setBoitier(string boitier) { this.boitier = boitier; }
        public void setDisqueDur(string disqueDur) { this.disqueDur = disqueDur; }
        public void setMemoireRAM(string memoireRAM) { this.memoireRAM = memoireRAM; }
        public void setCarteGraphique(string carteGraphique) { this.carteGraphique = carteGraphique; }
        public void setProcesseur(string processeur) { this.processeur = processeur; }
        public void setCarteSon(string carteSon) { this.carteSon = carteSon; }

        public void Informations()
        {
            Console.WriteLine("Tour creee : " + alimentation + ", " +
                carteMere + ", " + boitier + ", " + disqueDur + ", " +
                memoireRAM + ", " + carteGraphique + ", " + processeur + ", " +
                carteSon);
        }
    }
}
