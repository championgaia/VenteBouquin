using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabseFirst2
{
    public class Toto
    {

        public void DisplayAllContactNames()
        {
            List<Customers> resultats = new List<Customers>();

            //var context = new NorthwindDbEntities();
            //resultats = context.Customers.ToList();
            //context.Dispose();

            Customers c = new Customers();
            using (var context = new NorthwindDbEntities())
            {
                //recuperer tous les customers
                //resultats = context.Customers.ToList();

                //recuperer blonp uniquement
                c = context.Customers.FirstOrDefault(cu => cu.CustomerID == "BLONP");

               var orders =  c.Orders.ToList();

                foreach (var od in orders)
                {
                    Console.WriteLine(od.OrderDate);
                }

            }

            //foreach (var item in resultats)
            //{
            //    Console.WriteLine(item.ContactName);
            //}
            Console.ReadKey();
        }

    }
}
