using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.AstractFactory
{
    #region IFabricable
    public interface IFabricable
    {
        Vehicule CreerVoiture();
        Vehicule CreerScooter();
    }
    #endregion
    #region IFabricableEssence
    public interface IFabricableEssence : IFabricable
    {

    }
    #endregion
    #region IFabricableElectrique
    public interface IFabricableElectrique : IFabricable
    {

    }
    #endregion
    #region FabriqueElectrique
    public class FabriqueElectrique : IFabricable
    {
        public Vehicule CreerScooter()
        {
            return new ScooterElectrique();
        }
        public Vehicule CreerVoiture()
        {
            return new VoitureElectrique();
        }
    }
    #endregion
    #region FabriqueEssence
    public class FabriqueEssence : IFabricable
    {
        public Vehicule CreerScooter()
        {
            return new ScooterEssence();
        }
        public Vehicule CreerVoiture()
        {
            return new VoitureEssence();
        }
    }
    #endregion
}
