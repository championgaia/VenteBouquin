using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new Zoo();

            zoo.AjouterAnimal(new Animal("Chien"));
            zoo.AjouterAnimal(new Animal("Tigre"));
            zoo.AjouterAnimal(new Animal("Eléphant"));

            Console.WriteLine("Entre un entier entre 0 et 2");
            while (int.TryParse(Console.ReadLine(), out var entier))
            {
                if (entier >= 0 && entier < zoo.NombreAnimaux)
                {
                    zoo.GetAnimal(entier).Appeler();
                    Console.WriteLine("Entre un entier entre 0 et 2");
                }
                else
                    break;
            }
        }
    }
}
