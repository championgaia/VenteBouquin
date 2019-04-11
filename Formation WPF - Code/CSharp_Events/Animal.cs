using System;
using System.Collections.Generic;

namespace CSharp_Events
{
    public class Animal
    {
        public event EventHandler Appel;

        public Animal(string type)
        {
            Type = type;
        }

        public string Type { get; }

        public void Appeler()
        {
            Appel?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Zoo
    {
        private List<Animal> _animaux = new List<Animal>();

        public int NombreAnimaux => _animaux.Count;

        public Animal GetAnimal(int entier)
        {
            return _animaux[entier];
        }

        public void AjouterAnimal(Animal animal)
        {
            _animaux.Add(animal);
            animal.Appel += Animal_Appel;
        }

        private void Animal_Appel(object sender, EventArgs e)
        {
            var animal = (Animal)sender;
            Console.WriteLine($"{animal.Type} appelle!");
        }
    }
}
