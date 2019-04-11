using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf01_03_Morpion.classes
{
    public class Personne
    {
        public string Nom { get; set; }
    }
    public class Personnes
    {
        public Personne P1 { get; set; }
        public void GetPersonne()
        {
            Console.WriteLine(P1?.Nom.ToUpper());
        }
    }
}
