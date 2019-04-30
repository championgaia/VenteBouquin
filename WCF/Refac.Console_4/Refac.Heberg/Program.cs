using Refac.ServiceWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Refac.Heberg
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(PartiePendu)))
            {
                host.Open();

                Console.ReadKey();
            }

        }
    }
}
