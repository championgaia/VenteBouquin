using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class PromotionModel
    {
        public int CodePromotionM { get; set; }
        public double PourcentagePromoM { get; set; }
        public DateTime DateDebutM { get; set; }
        public DateTime DateFinM { get; set; }
    }
}