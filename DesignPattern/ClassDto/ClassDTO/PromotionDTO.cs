using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDto.ClassDTO
{
    public class PromotionDTO
    {
        public int CodePromotionDto { get; set; }
        public double PourcentagePromo { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}
