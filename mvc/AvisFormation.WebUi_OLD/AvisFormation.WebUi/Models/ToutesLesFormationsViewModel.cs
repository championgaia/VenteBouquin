using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.WebUi.Models
{
    public class ToutesLesFormationsViewModel
    {
        public ToutesLesFormationsViewModel()
        {
            Formations = new List<Formation>();
        }

        public string Ville { get; set; }
        public List<Formation> Formations { get; set; }
    }
}