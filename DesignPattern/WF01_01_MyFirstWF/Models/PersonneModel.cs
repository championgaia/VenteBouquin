﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF01_01_MyFirstWF.Models
{
    public class PersonneModel
    {
        public string NomM { get; set; }
        public string PrenomM { get; set; }
        public string DateNaissanceM { get; set; }
        public PersonneModel()
        {

        }
        public PersonneModel(string nom, string prenom, string dateNaissance)
        {
            NomM = nom;
            PrenomM = prenom;
            DateNaissanceM = dateNaissance;
        }

    }
}