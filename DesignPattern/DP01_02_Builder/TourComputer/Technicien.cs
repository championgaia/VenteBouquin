using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_02_Builder.TourComputer
{
    public class Technicien
    {
        private MonteurTour monteurTour;

        public void setMonteurTour(MonteurTour m) { monteurTour = m; }
        public Tour getTour() { return monteurTour.getTour(); }

        public void construireTour()
        {
            monteurTour.creerNouvelleTour();
            monteurTour.monterAlimentation();
            monteurTour.monterCarteMere();
            monteurTour.monterBoitier();
            monteurTour.monterDisqueDur();
            monteurTour.monterMemoireRAM();
            monteurTour.monterCarteGraphique();
            monteurTour.monterProcesseur();
            monteurTour.monterCarteSon();
        }
    }
}
