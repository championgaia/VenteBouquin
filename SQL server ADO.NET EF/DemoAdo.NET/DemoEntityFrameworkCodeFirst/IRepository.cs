using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFrameworkCodeFirst
{
    public interface IRepository
    {
        Customers GetCustomersById(string id);
        Customers GetCustomersByIdNoTracking(string id);
        IEnumerable<Customers> GetCustomers();
    }
}
