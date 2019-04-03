using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_02_Builder.TourComputer
{
    public abstract class MonteurTour
    {
        protected Tour tour;

        public Tour getTour() { return tour; }
        public void creerNouvelleTour() { tour = new Tour(); }

        public abstract void monterAlimentation();
        public abstract void monterCarteMere();
        public abstract void monterBoitier();
        public abstract void monterDisqueDur();
        public abstract void monterMemoireRAM();
        public abstract void monterCarteGraphique();
        public abstract void monterProcesseur();
        public abstract void monterCarteSon();
    }
}
