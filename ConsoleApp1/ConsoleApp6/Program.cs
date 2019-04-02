using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            string saisie; 
            int checkOut = 1;
            do
            {
                saisie = Console.ReadLine();
                if (checkOut != 0)
                {
                    Console.WriteLine("Reenter a number");
                    saisie = Console.ReadLine();
                }
                else
                    break;
            } while (int.TryParse(saisie, out checkOut));
            Console.Read();
        }
    }
}
