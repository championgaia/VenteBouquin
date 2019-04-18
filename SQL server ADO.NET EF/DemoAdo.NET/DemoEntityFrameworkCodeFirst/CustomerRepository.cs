using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFrameworkCodeFirst
{
    public class CustomerRepository
    {

        public List<Customers> GetCustomers(string name=null,string address = null, string region = null)
        {
            List<Customers> result = new List<Customers>();


            using (var context = new NorthwindDbContext())
            {
                IQueryable<Customers> customers = context.Customers;//.ToList()
                if (!String.IsNullOrEmpty(name))
                    customers = customers.Where(c => c.ContactName == name);
                if (!String.IsNullOrEmpty(address))
                    customers = customers.Where(c => c.Address == address);
                if (!String.IsNullOrEmpty(region))
                    customers = customers.Where(c => c.Region == region);

                result = customers.ToList();
            }

            //var query = "SELECT * FROM Customers WHERE 1=1";
            //if (!String.IsNullOrEmpty(name))
            //    query += " AND contactname =" + name;
            //if (!String.IsNullOrEmpty(address))
            //    query += " AND address =" + address;
            //if (!String.IsNullOrEmpty(region))
            //    query += " AND address =" + region; 
            //executer la query et recuperer les données
            return result;
        }

    }
}


 
