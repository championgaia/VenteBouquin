using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dat1 = new DateTime(2008, 5, 1, 8, 30, 52);
            Console.WriteLine(dat1);

            DateTime dat2 = new DateTime();
            // The following method call displays 1/1/0001 12:00:00 AM.
            Console.WriteLine("La valeur de dat2  " + dat2.ToString(System.Globalization.CultureInfo.InvariantCulture));
            // The following method call displays True.
            Console.WriteLine("La deuxième valeur de dat2  " + dat2.Equals(DateTime.MinValue));


            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.UtcNow;
            DateTime date3 = DateTime.Today;

            // Chercher comment afficher


            Console.Read();
        }
    }
}
