namespace Ado05_01_Event
{
    internal class BusinessClass2
    {
        

        public BusinessClass2(EventMannagerAndPublisher event1)
        {
            event1.MyEvent += Event1_MyEvent;
        }

        private void Event1_MyEvent(object sender, ObjetATransmettre e)
        {
            System.Console.WriteLine(this + "start");
        }
    }
}