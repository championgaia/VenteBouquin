using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_04_Prototype.InterfaceAbstract
{
    public abstract class Prototype
    {
        public abstract Prototype clone();

        public abstract void Informations();
    }
}
