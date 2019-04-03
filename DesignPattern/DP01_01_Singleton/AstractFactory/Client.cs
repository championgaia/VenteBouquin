using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    public class Client
    {
        public List<Vehicule> MesCatalogue;
        #region constructor
        public Client(IFabricable factory)
        {
            Vehicule voiture1 = factory.CreerVoiture();
            Vehicule scooter1 = factory.CreerScooter();
            MesCatalogue = new List<Vehicule> { voiture1, scooter1 };
        }
        #endregion
        #region Afficher
        public void Afficher() 
        {
            if (MesCatalogue != null)
            {
                foreach (var item in MesCatalogue)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("there is nothing inside our catalogue");
        }
        #endregion
    }
}
