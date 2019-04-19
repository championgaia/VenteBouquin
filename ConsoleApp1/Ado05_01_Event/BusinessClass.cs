using System;

namespace Ado05_01_Event
{
    internal class BusinessClass 
    {
        public BusinessClass()
        {

        }
        public BusinessClass(EventMannagerAndPublisher e)
        {
            e.MyEvent += Examplemethode;
        }
        public void Examplemethode(object sender, ObjetATransmettre e)
        {
            Console.WriteLine(this+"start");
        }
    }
}