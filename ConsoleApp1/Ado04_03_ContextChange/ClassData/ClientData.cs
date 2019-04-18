using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado04_03_ContextChange.ClassData
{
    public class ClientData
    {
        private NorthWindContext Context = new NorthWindContext();
        #region AddField
        public void AddField()
        {
            var client = Context.Customers.Where(c => c.CustomerID == "HILAA").FirstOrDefault();
            client.Email = "hilago@free.fr";
            Context.SaveChanges();
        }
        #endregion
        #region Inserer nouveau customer
        public void AddRow()
        {
            //Context.Customers.Add(new Customers()
            //{
            //    CustomerID = "ABCDE",
            //    CompanyName = "DORANCO"
            //});
            Context.Customers.AddOrUpdate(new Customers()
            {
                CustomerID = "ABCDE",
                CompanyName = "DORANCO"
            });
            Context.SaveChanges();
        }
        #endregion
        #region Delete customer
        public void DeleteRow()
        {
            //var client = Context.Customers.Where(c => c.CustomerID == "ABCDE").FirstOrDefault();
            //Context.Customers.Remove(client);
            Context.Customers.RemoveRange(Context.Customers.Where(c => c.CustomerID == "ABCDE"));
            Context.SaveChanges();
        }
        #endregion
        #region GetCustomers
        public List<Customers> GetCustomers
            (string name = "0", string addresse = "0", string region = "0")
        {
            List<Customers> mesCustomer = new List<Customers>();
            //    Text =
            //(
            //    n == 1 ? "One" :
            //    n == 2 ? "Two" :
            //    n == 3 ? "Three" : "Unknown"
            //)

            mesCustomer = Context.Customers.Where(c =>  (name != "0") ? c.ContactName == name :
                                                    (addresse != "0") ? c.Address == addresse :
                                                    (region != "0")   ? c.Region == region : (1==1)).ToList();  
            return mesCustomer;
        }
        #endregion
        #region GetCustomers
        public List<Customers> GetCustomersAsQuerry
            (string name = "0", string addresse = "0", string region = "0")
        {
            var mesCustomer = Context.Customers.AsQueryable();

            mesCustomer = (name != "0") ? mesCustomer.Where(c => c.ContactName == name) : mesCustomer;
            mesCustomer = (addresse != "0") ? mesCustomer.Where(c => c.Address == addresse) : mesCustomer;
            mesCustomer = (region != "0") ? mesCustomer.Where(c => c.Region == region) : mesCustomer;
            return mesCustomer.ToList();
        }
        #endregion

    }
}
