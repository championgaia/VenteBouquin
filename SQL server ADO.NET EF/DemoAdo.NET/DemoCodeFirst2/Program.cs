using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var context = new NorthWindDbContext())
            {
                var customers = context.Customers.ToList();
            }
        }
    }
}
