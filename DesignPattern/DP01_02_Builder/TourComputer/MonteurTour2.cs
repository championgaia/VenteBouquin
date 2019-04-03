using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_02_Builder.TourComputer
{
    public class MonteurTour2 : MonteurTour
    {
        public override void monterAlimentation() { tour.setAlimentation("Alimentation 2"); }

        public override void monterCarteMere() { tour.setCarteMere("Carte mere DTX"); }

        public override void monterBoitier() { tour.setBoitier("Boitier moyen"); }

        public override void monterDisqueDur() { tour.setDisqueDur("DD 5400 tours"); }

        public override void monterMemoireRAM() { tour.setMemoireRAM("2048Mo"); }

        public override void monterCarteGraphique() { tour.setCarteGraphique("Nvidia Geforce GT 430"); }

        public override void monterProcesseur() { tour.setProcesseur("Intel Dual Core 2 3.16 GHz"); }

        public override void monterCarteSon() { tour.setCarteSon("Creative Sound Blaster X-Fi Titanium"); }
    }
}
