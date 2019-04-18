using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFrameworkCodeFirst
{
    class CustomerAndOrder
    {
        public DateTime? OrderDate { get; internal set; }
        public string CustomerName { get; internal set; }
    }
}
