using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.WebUi.Models
{
    public class DetailFormationViewModel
    {
        public DetailFormationViewModel()
        {
            FormationInstance = new Formation();
        }

        public Formation FormationInstance { get; set; }
        public double NoteMoyenne { get; set; }
    }
}