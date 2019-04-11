using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReferenceNullable
{
    class Program
    {
        static void Main(string[] args)
        {
            new Personnes().GetPersonne();
            Console.Read();
        }
    }
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
