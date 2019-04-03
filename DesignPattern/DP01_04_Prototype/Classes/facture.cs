using DP01_04_Prototype.InterfaceAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_04_Prototype.Classes
{
    public class Facture : Prototype
    {
        String numFacture = "";
        String client = "";

        public Facture(String Client)
        {
            this.client = Client;
        }

        public override Prototype clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override void Informations()
        {
            Console.WriteLine("Facture nÂ°{0} generee pour {1}", numFacture, client);
        }

        public void SetNumFacture(String Facture)
        {
            this.numFacture = Facture;
        }
    }
}
