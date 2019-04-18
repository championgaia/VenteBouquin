using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Temp";
            ListFolderFiles a = new ListFolderFiles();
            //a.ShowLargeFilesWithoutLINQ(path);
            // a.ShowLargeFilesWithLINQ(path);

            // LamdbaTest l = new LamdbaTest();
            // l.FunWithLambda();

            //  var ex = new ExercicesLinqpresentation();
            //  ex.Exercice2_250();
            //  ex.Exercice3_Division();
            // ex.Exercice1_NombresPairs();

            //var ex2 = new ExercicesLinqPresentation2();
            //ex2.Exercice6();

            var exercices = new ExercicesLinq();
            exercices.ExerciceDur_SFindUppercase();

            //var bench = new BenchmarkAgregateSum();
            //bench.Start();
        }
    }
}
