using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Donnez moi un chiffre entre 10 et 100 : ");
            // String chaine = "TOTO";
            string chaine = Console.ReadLine();

            Console.WriteLine("Vous avez donné la valeur : " + chaine);

            // Convertire la valeur contenue dans chaine (string) en une valeur de tyupe entier :
            int valeurDeChaine = Convert.ToInt32(chaine);

            int valeurAuCarré = valeurDeChaine * valeurDeChaine;

            Console.WriteLine("le Carré de : " + chaine + " est égal à " + valeurAuCarré.ToString());

            Console.Read();
        }
    }
}
