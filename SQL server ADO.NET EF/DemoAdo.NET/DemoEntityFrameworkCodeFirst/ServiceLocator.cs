using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DemoEntityFrameworkCodeFirst
{
    public static class ServiceLocator
    {
        private static IUnityContainer container;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new UnityContainer();
                    container.RegisterType<IRepository, ConnectedRepository>();
                }
                return container;
            }
        }
    }
}
