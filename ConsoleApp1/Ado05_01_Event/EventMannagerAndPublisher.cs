using System;

namespace Ado05_01_Event
{
    internal class EventMannagerAndPublisher
    {
        public event EventHandler<ObjetATransmettre> MyEvent;
        public EventMannagerAndPublisher()
        {
        }
        public void Publier()
        {   
            Console.WriteLine("Avant publier");
            //code a transmettre
            MyEvent(this, new ObjetATransmettre { Message = "Blablabla" });
            Console.WriteLine("Apres publier");
        }
    }
}