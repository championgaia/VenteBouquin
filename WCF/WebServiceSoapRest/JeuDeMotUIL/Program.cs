using JeuDeMotBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMotUIL
{
    class Program
    {
        static void Main(string[] args)
        {
            JeuxMotUIL jeux = new JeuxMotUIL();
            jeux.Play();
            Console.Read();
        }
    }
}
