using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado02_01_ConnectionString
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public override string ToString()
        {
            return string.Format(CustomerId + CompanyName + ContactName);
        }
    }
}
