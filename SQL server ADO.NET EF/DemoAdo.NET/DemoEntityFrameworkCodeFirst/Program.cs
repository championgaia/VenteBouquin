using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DemoEntityFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            //var r = new Rectangle(5, 4);
            //var perimetre = r.CalculPérimetre();

            //if (perimetre != 18)
            //    throw new Exception("le calcul du perimetre n'est pas bon");

            //var c = new Carre(5, 4);
            // perimetre = c.CalculPérimetre();

            //if (perimetre != 18)
            //    throw new Exception("le calcul du perimetre n'est pas bon");






            using (var context = new NorthwindDbContext())
            {
                //var customer = context.Customers.FirstOrDefault(c => c.ContactName == "Maria Anders");


                //var orders = context.Customers.FirstOrDefault(c => c.ContactName == "Maria Anders").Orders;

                //var orders2 = context.Customers.Include(c=>c.Orders).FirstOrDefault(c => c.ContactName == "Maria Anders").Orders;


                //var c2 = new CustomerRepository();
                ////var results = c2.GetCustomers();
                //var results2 = c2.GetCustomers("Maria Anders");


                //var customerOrders = from cust in context.Customers
                //                     join ord in context.Orders on cust.CustomerID equals ord.CustomerID
                //                     select new CustomerAndOrder { OrderDate = ord.OrderDate, CustomerName = cust.ContactName };

                //var customerOrders2 = context.Customers.Join(context.Orders,
                //                     customer => customer.CustomerID,
                //                     order => order.CustomerID,
                //                     (customer, order) => new CustomerAndOrder
                //                     {
                //                         OrderDate = order.OrderDate,
                //                         CustomerName = customer.ContactName
                //                     });

                //var customerOrdersLeftJoin = from cust in context.Customers
                //                     join ord in context.Orders on cust.CustomerID equals ord.CustomerID into joined
                //                     from ord in joined.DefaultIfEmpty()
                //                     select new CustomerAndOrder { OrderDate = ord.OrderDate, CustomerName = cust.ContactName };

                //foreach (var item in customerOrders)
                //{
                //    System.Diagnostics.Debug.WriteLine(item.CustomerName + " " + item.OrderDate);
                //}

                //var listorders = from cust in context.Customers
                //                 join ord in context.Orders on cust.CustomerID equals ord.CustomerID
                //                 join od in context.Order_Details on ord.OrderID equals od.OrderID
                //                 select new { cust.ContactName, od.Quantity,od.UnitPrice };
                //foreach (var item in listorders)
                //{
                //    System.Diagnostics.Debug.WriteLine(item.ContactName + " " + item.Quantity+ " " + item.UnitPrice);
                //}

                //var entity = context.Customers.FirstOrDefault(c => c.ContactName == "Maria Anders");
                //entity.CompanyName = "MyCompany";
                //context.SaveChanges();

                //var order = new Orders();
                //order.CustomerID = "ALFKI";
                //order.EmployeeID = 1;
                //order.OrderDate = DateTime.Now;
                ////order.OrderID à ne pas spécifier car champ IDENTITY
                //context.Orders.Add(order);
                //context.SaveChanges();

                //var orderToRemove =context.Orders.Where(o=>o.CustomerID == "ALFKI" && o.EmployeeID == 1).OrderByDescending(o=>o.OrderID).FirstOrDefault();

                //if(orderToRemove != null)
                //{
                //    context.Orders.Remove(orderToRemove);
                //    context.SaveChanges();
                //}

                //var entityFind = context.Customers.Find("ALFKI");

                //using (ConnectedRepository context = new ConnectedRepository())
                //{
                //   IEnumerable<Customers> customers = context.GetCustomers();

                //}
                var repo = ServiceLocator.Container.Resolve<IRepository>();



                MaClasseAvecInjection injected2 = new MaClasseAvecInjection(repo);

                injected2.Execute();



            }
        }
    }
}
