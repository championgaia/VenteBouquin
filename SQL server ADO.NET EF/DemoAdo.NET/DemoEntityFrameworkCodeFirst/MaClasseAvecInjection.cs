using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DemoEntityFrameworkCodeFirst
{
    public class MaClasseAvecInjection
    {
         IRepository _repository;

        //public MaClasseAvecInjection()
        //{
        //    _repository = ServiceLocator.Container.Resolve<IRepository>();
        //}
        public MaClasseAvecInjection(IRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
           var listCustomers = _repository.GetCustomers();

            foreach (var item in listCustomers)
            {
                System.Diagnostics.Debug.WriteLine(item.ContactName);
            }

        }

    }
}
