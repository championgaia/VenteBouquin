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
