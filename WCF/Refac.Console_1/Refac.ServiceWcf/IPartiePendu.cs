using Refac.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Refac.ServiceWcf
{
    [ServiceContract]
    public interface IPartiePendu
    {
        [OperationContract]
        Partie VerifierLettre(Partie p, string lettre);

    }
}
