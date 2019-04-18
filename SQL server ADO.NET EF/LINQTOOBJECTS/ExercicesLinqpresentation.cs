using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    public class ExercicesLinqpresentation
    {

        public void Exercice2_250()
        {
            var list = Enumerable.Range(0, 500).ToList();

           int result = list.FirstOrDefault(n => n == 250);

           //var result2 = list.Where(n => n == 250).FirstOrDefault();

            Console.WriteLine(result);
            Console.ReadKey();
        }
        public void Exercice3_Division()    
        {
            var list = Enumerable.Range(0, 500).ToList();

            var results = list.Select(n => (float)n /2 ).ToList();

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public void Exercice1_NombresPairs()
        {
            var list = Enumerable.Range(0, 500).ToList();

            var results = list.Where(n => (n%2 ==0));

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
