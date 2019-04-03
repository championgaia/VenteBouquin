using DP01_04_Prototype.InterfaceAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_04_Prototype.Classes
{
    public class BonCommande : Prototype
    {
        String numCommande = "";
        String client = "";

        public BonCommande(String Client)
        {
            this.client = Client;
        }

        public override Prototype clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override void Informations()
        {
            Console.WriteLine("Bon de commande nÂ°{0} genere pour {1}", numCommande, client);
        }

        public void SetNumCommande(String numCommande)
        {
            this.numCommande = numCommande;
        }
    }
}
