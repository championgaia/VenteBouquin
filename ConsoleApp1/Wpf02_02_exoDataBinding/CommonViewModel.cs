using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf02_02_exoDataBinding
{
    public class CommonViewModel
    {
        public List<Contact> LesContacts { get; set; }
        public List<Pays> LesPays { get; set; }
        public CommonViewModel()
        {
            LesContacts = new List<Contact>();
            LesPays = new List<Pays>();
            LesContacts = Contact.LoadContacts();
            LesPays = Pays.LoadPays();
        }
    }
}
