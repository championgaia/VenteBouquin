using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado02_01_ConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
            Manipulation manip = new Manipulation();
            manip.GetCustomers();
            manip.GetCustomers("Paris");
            Console.WriteLine(manip.GetCustomersClass("Paris"));
            manip.GetSalesByCategoryPS("Beverages", "SalesByCategory", "@CategoryName");
            Console.Read();
        }
    }
}
