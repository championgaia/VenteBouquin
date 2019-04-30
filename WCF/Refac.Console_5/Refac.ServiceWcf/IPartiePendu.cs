using Refac.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//  <ProjectTypeGuids>{3D9AD99F-2412-4246-B90B-4EAA41C64699};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>
namespace Refac.ServiceWcf
{
    [ServiceContract]
    public interface IPartiePendu
    {
       [OperationContract]
        Partie VerifierLettre(Partie p, string lettre);
    }
}
