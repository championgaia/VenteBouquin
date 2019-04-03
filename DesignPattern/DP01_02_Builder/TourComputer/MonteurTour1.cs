using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_02_Builder.TourComputer
{
    public class MonteurTour1 : MonteurTour
    {
        public override void monterAlimentation() { tour.setAlimentation("Alimentation 1"); }

        public override void monterCarteMere() { tour.setCarteMere("Carte mere ATX"); }

        public override void monterBoitier() { tour.setBoitier("Boitier moyen"); }

        public override void monterDisqueDur() { tour.setDisqueDur("DD 7200 tours"); }

        public override void monterMemoireRAM() { tour.setMemoireRAM("1024Mo"); }

        public override void monterCarteGraphique() { tour.setCarteGraphique("ATI Radeon"); }

        public override void monterProcesseur() { tour.setProcesseur("Intel Dual Core 2 3.16 GHz"); }

        public override void monterCarteSon() { tour.setCarteSon("Creative Sound Blaster X-Fi Titanium"); }
    }
}
