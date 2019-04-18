using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DemoLinq
{
    internal class BenchmarkAgregateSum
    {
        public BenchmarkAgregateSum()
        {
        }

        internal void Start()
        {
            var list = Enumerable.Range(0, 50000000).ToList();

            List<long> longs = list.ConvertAll(i => (long)i);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var sum = longs.Sum();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            var memory1 = Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine(memory1);

            var watch2 = System.Diagnostics.Stopwatch.StartNew();

            var sum2 = longs.Aggregate((a, b) => a + b);

            watch2.Stop();
            Console.WriteLine(watch2.ElapsedMilliseconds);

            var memory2 = Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine(memory2);





        }
    }
}