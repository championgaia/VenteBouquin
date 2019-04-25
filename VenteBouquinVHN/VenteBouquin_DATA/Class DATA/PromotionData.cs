using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenteBouquin_DATA.Class_DATA
{
    internal class PromotionData
    {
        public int CodePromotion { get; set; }
        public double PourcentagePromo { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}
