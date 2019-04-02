using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int i = 0;
            Personne myconsole = new Personne();
            
            // Caractères d'échappement
            //string myString = "Bonjour à tous pour ce nouveau module";
            //String myString = "C:\\tmp\\monfichier.txt";
            //String myString = "Bonjour à tous pour ce nouveau module";
            //String myString2 = "\tBonjour à tous pour ce nouveau module";
            //String myString = "Bonjour à tous \npour ce nouveau module";

            // String.Format
            //String myString = String.Format("Le prix à payer est de {0} pour l'article {1}", 12.5, "Pot");
            String myString = String.Format("Le prix à payer est de {0:C} pour l'article {1}", 5000000000, "Pot");
            Console.WriteLine(myString);
            //DateTime myDate = DateTime.Now;
            //String myString = String.Format("Nous sommes le {0:d}", myDate);


            // Potentiellement prob de performances et de mémoire
            //String myString = "Bonjour";
            //myString = myString + " à ";
            //myString = myString + " tous ";
            //myString += " pour ce nouveau";
            //myString += " cours MVA sur ";
            //myString += " les chaines de caractères";

            // Concaténation de chaines de caractères.
            StringBuilder builder = new StringBuilder();
            builder.Append("Bonjour");
            builder.Append(" à ");
            builder.Append(" tous ");
            builder.Append(" pour ce nouveaux cours MVA");
            builder.Append(" sur les chaines de caractères.");
            Console.WriteLine(builder);

            //string myString = "     Bonjour à tous pour ce nouveau module.     ";
            Console.WriteLine(myString.Replace("o", "").Trim().ToUpper().Substring(0, 8));

            Console.Read();
        }
    }

    internal class Personne
    {
    }
}
