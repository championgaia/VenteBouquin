using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvisFormation.WebUi.Models
{
    public class AvisViewModel
    {
        [Required]
        public string Note { get; set; }


        [MaxLength(20)]
        public string Commentaire { get; set; }


        [Required]
        public string Nom { get; set; }


        public string IdFormation { get; set; }
    }
}