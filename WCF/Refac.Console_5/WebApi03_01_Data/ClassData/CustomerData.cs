using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi03_01_Data.ClassData
{
    internal class CustomerData
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Compagny { get; set; }
        private NorthWindContext context = new NorthWindContext();

        public void CreateCustomer()
        {
            Customer cus = new Customer
            {
                CustomerID = Id,
                ContactName = Nom,
                CompanyName = Compagny
            };
            context.Customers.Add(cus);
            context.SaveChanges();
        }

        public void DeleteCustomer(string id)
        {
            List<Customer> maList = new List<Customer>
            {
                context.Customers.FirstOrDefault(c=>c.CustomerID == id)
            };
            context.Customers.RemoveRange(maList);
            context.SaveChanges();
        }
    }
    internal class CustomerDatas
    {
        public List<CustomerData> LesCustomers { get; set; }
        private NorthWindContext context = new NorthWindContext();

        public CustomerDatas()
        {
            LesCustomers = new List<CustomerData>();
                foreach (var item in context.Customers.Select(c => c))
                {
                    LesCustomers.Add(new CustomerData
                    {
                        Id = item.CustomerID,
                        Nom = item.ContactName,
                        Compagny = item.CompanyName
                    });
                }
        }
    }
}
