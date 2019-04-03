using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO03042019
{
    class Program
    {
        static void Main(string[] args)
        {
            Manipulation manip = new Manipulation();
            Console.WriteLine(manip.Addition(12,24));
            Console.WriteLine(manip.Division(12, 24));
            Console.Read();
        }

    }
    public class Manipulation
    {
        public double Addition(double param1, double param2)
        {
            return param1 + param2;
        }
        public double Division(double param1, double param2)
        {
            return param1 / param2;
        }
    }
}
