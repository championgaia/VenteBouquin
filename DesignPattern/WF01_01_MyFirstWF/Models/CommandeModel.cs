using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF01_01_MyFirstWF.Models
{
    public class CommandeModel
    {
        public int CodeCommandeM { get; set; }
        public double PrixTotalM { get; set; }
        public PayeurModel LePayeurM { get; set; }
        public List<LigneDeCommandeModel> LesLignesM { get; set; }
    }
}