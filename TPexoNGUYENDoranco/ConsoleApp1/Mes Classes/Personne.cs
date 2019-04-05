using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Mes_Classes
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public bool Emploi { get; set; }
        public Personne()
        {

        }
        public Personne(string nom, string prenom, string adresse, bool emploi)
        {
            Nom = nom; Prenom = prenom; Adresse = adresse; Emploi = emploi;
        }
    }
}
