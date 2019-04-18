using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFrameworkCodeFirst
{
    public class ConnectedRepository : IRepository
    {
        private readonly NorthwindDbContext _context = new NorthwindDbContext();

        public Customers GetCustomersById(string id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerID == id);
        }
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers;
        }

        public Customers GetCustomersByIdNoTracking(string id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerID == id);
        }
    }
}
