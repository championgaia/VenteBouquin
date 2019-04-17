using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo.NET
{
    public class Order
    {
        public int OrderId { get; internal set; }
        public string ShipName { get; internal set; }
        public string ShipAddress { get; internal set; }
        public int EmployeeId { get; internal set; }
    }
}
