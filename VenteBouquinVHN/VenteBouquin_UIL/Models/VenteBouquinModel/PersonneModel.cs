using System;
using System.Collections.Generic;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class PersonneModel
    {
        public int CodePersonneM { get; set; }
        public string NomM { get; set; }
        public string PrenomM { get; set; }
        public DateTime DateNaissanceM { get; set; }
        public List<AdresseModel> ListeAdresseM { get; set; }
    }
}