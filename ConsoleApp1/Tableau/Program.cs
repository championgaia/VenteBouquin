using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tableau
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myTable = new int[7];
            int[] my2Table = new int[] { 12, 23, 445, 4545, 54, 5, 123 };
            int[] my3Table = { 2445, 523, 444, 4588, 7787, 455, 55 };
            Array.Sort(my2Table);
            Array.Reverse(my2Table);
            Array.Resize(ref myTable, 8);
            for (int i = 0; i < my2Table.Length; i++)
            {
                Console.WriteLine(my2Table[i]);
            }
            for (int i = 0; i < my3Table.Length; i++)
            {
                Console.WriteLine(my3Table[i]);
            }
            foreach (var item in my2Table)
            {
                Console.WriteLine(item);
            }

            int[,] table3 = { { 1, 2, 3, 4, 5, 6 }, { 10, 20, 30, 40, 50, 60 } };
            for (int i = 0; i < table3.GetLength(0); i++)
            {
                for (int j = 0; j < table3.GetLength(1); j++)
                {
                    Console.WriteLine("i={0} j={1}", i, j);
                }

            }
            Console.Read();
        }
    }
}
