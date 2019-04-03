using DP01_01_Singleton.AstractFactory;
using DP01_01_Singleton.DesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //TableManipulation tableManip = new TableManipulation();
            new Client(new FabriqueElectrique()).Afficher();
            Console.Read();
        }
    }
    
}
