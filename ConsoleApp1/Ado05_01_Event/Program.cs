using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado05_01_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. exposer dans cette class un event
            EventMannagerAndPublisher event1 = new EventMannagerAndPublisher();
            //2. Trouver un moyen de partager l'instance de l'event avec mes BusinessClass
            //3. Souscrive à l'event
            //4. Creer la methode pour consomer l'event
            ObjetATransmettre myObjet = new ObjetATransmettre();
            BusinessClass bc1 = new BusinessClass(event1);
            BusinessClass2 bc2 = new BusinessClass2(event1);

            
            //5. implementer le code de la publication
            event1.Publier();
            Console.Read();
        }

        
    }
}
