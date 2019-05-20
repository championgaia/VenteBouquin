using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            new Manipulation().Comparer(10);
        }
    }
    class Manipulation
    {
        public void Comparer(int a)
        {
            if (a == 10)
            {
                Console.WriteLine("a egal 10");
            }
            else if (a != 8)
            {
                Console.WriteLine("a différent à 8");
            }
            else
            {
                Console.WriteLine("djhjhzdhshhshdhshdsjhdjh");
            }
        }
    }
}
