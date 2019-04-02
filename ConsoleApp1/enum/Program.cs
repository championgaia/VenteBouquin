using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @enum
{
    class Program
    {
        static void Main(string[] args)
        {
            Jours myDate;
            //
            myDate = Jours.mar;
            myDate = 0;
            Console.WriteLine(myDate);
            foreach (var item in Enum.GetValues(typeof(Jours)))
            {
                Console.WriteLine(item);
            }
            
            Console.Read();
        }
        enum Jours { lun, mar , mer, jeu, ven, sam, dim};
        
    }
}
