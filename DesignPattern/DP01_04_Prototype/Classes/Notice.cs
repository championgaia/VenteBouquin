using DP01_04_Prototype.InterfaceAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_04_Prototype.Classes
{
    public class Notice : Prototype
    {
        public override Prototype clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override void Informations()
        {
            Console.WriteLine("Notice d'utilisation generee");
        }
    }
}
