using DP01_04_Prototype.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_04_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            string numFacture1 = "F.2011.001";
            string numFacture2 = "F.2011.002";

            string Client1 = "Jean-Michel";
            string Client2 = "Philippe";

            Facture f1 = new Facture(Client1);
            f1.SetNumFacture(numFacture1);
            Console.WriteLine("1ere sortie :  ");
            f1.Informations();

            Facture f2 = (Facture)f1.clone();
            Console.WriteLine("2eme sortie :  ");
            f2.Informations(); // Avant modification du numero de facture
            f2.SetNumFacture(numFacture2);
            Console.WriteLine("3eme sortie :  ");
            f2.Informations(); // Apres modification

            Console.ReadKey();
        }
    }
}
