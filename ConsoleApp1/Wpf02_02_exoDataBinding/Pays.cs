using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf02_02_exoDataBinding
{
    public class Pays
    {
        public string Nom { get; set; }
        public static List<Pays> LoadPays()
        {
            var LesPays = new List<Pays>
            {
                new Pays() { Nom = "France" },
                new Pays() { Nom = "Germany" }
            };
            return LesPays;
        }
    }
    
    public class  MesPays
    {
        public List<Pays> ListePays { get; set; }
        #region constructeur par default
        public MesPays()
        {

        }
        #endregion
        #region constructeur par default
        public MesPays(List<Pays> listePays)
        {
            ListePays = listePays;
        }
        #endregion
    }
}
