using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMotData.ClassData
{
    internal class JeuDeMot
    {
        public string MonMot { get; set; }
        public string[] MonListMot { get; set; }
        private testContext context = new testContext();
        public JeuDeMot()
        {
            MonListMot = context.Mot.Select(c => c.MotLibelle).ToArray();
            MonMot = MonListMot[new Random().Next(0, MonListMot.Length - 1)];
        }
    }
}
