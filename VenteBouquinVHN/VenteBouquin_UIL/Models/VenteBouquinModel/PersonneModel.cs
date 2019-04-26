using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VenteBouquin_UIL.Models.VenteBouquinModel
{
    public class PersonneModel
    {
        public int CodePersonneM { get; set; }
        public string NomM { get; set; }
        public string PrenomM { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissanceM { get; set; }
        public List<AdresseModel> ListeAdresseM { get; set; }
    }
}