using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
   public class ExercicesLinqPresentation2
    {

        public void Exercice1()
        {
            var list = Enumerable.Range(0, 500).ToList();

           // var list2 = list.Where(n => (n % 3) == 0).ToList();

            var result = list.Where(n => (n %3)==0).Count();

            Console.WriteLine(result);
            Console.ReadKey();
        }
        public void Exercice2()
        {
            var list = Enumerable.Range(0, 500).ToList();

            var result = list.Where(n => n > 20).Sum();

            Console.WriteLine(result);
            Console.ReadKey();
        }
        public void Exercice3()
        {
            var list = Enumerable.Range(0, 500).ToList();

            var result = list.Where(n => (n % 3) == 0).Average();

            Console.WriteLine(result);
            Console.ReadKey();
        }
        public void Exercice4()
        {
            var list = Enumerable.Range(0, 500).ToList();
            //1
            var result = list.OrderByDescending(f=>f);

            // 2eme methode
            //list.Reverse();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
           

            Console.ReadKey();
        }
        public void Exercice5()
        {
            var list = Enumerable.Range(0, 500).ToList();
            var result = list.Min();
            Console.WriteLine(result);
            
            Console.ReadKey();
        }
        public void Exercice6()
        {
            var array1 = new int[] { 1, 2, 3, 4, 5 };
            var array2 = new int[] { 6, 7, 8, 9, 10 };

            var result = array1.Zip(array2, (l, n) => l + n);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
