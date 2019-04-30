using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.Data
{
    public class GenerateurDeMotADeviner
    {
        List<string> listMots = new List<string>();

        public GenerateurDeMotADeviner()
        {
            listMots.Add("SANDWICH");
            listMots.Add("TABLE");
            listMots.Add("TRAMONTANE");
            listMots.Add("HASHISCH");
            listMots.Add("KAYAK");
        }

        public string GetMot()
        {
            var r = new Random();
            var index = r.Next(0, listMots.Count-1);
            return listMots[index];
        }
    }
}
