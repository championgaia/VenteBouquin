using Ado04_03_ContextChange.ClassData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado04_03_UIL
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientData client = new ClientData();
            client.AddField();
            //client.DeleteRow();
            client.AddRow();
            //foreach (var item in client.GetCustomers("0", "0", "0"))
            //{
            //    Console.WriteLine(item.CompanyName);
            //}
            foreach (var item in client.GetCustomersAsQuerry(null, null, "SP"))
            {
                Console.WriteLine(item.CompanyName);
            }
            ;
            Console.Read();
        }
    }
}
