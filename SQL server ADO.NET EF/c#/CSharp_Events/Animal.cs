using System;
using System.Collections.Generic;

namespace CSharp_Events
{
    public class Animal
    {
        // Déclaration de l'événement Appel
        public event EventHandler<EventArgs> Appel;

        public Animal(string type)
        {
            Type = type;
        }

        public string Type { get; }

        public void Appeler()
        {
            // Ici, on déclenche l'événement Appel
            //   (si quelqu'un s'y est abonné)
            if (Appel != null)
                Appel(this, EventArgs.Empty);

            // Ci-dessous: équivalent
            //Appel?.Invoke(this, EventArgs.Empty);
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

            // Ici, on s'abonne à l'événement Appel
            //   et on "pointe" vers la méthode Animal_Appel
            animal.Appel += Animal_Appel;
        }

        private void Animal_Appel(object sender, EventArgs e)
        {
            var animal = (Animal)sender;
            Console.WriteLine($"{animal.Type} appelle!");
        }
    }
}
