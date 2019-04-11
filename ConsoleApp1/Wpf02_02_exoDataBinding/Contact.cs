using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf02_02_exoDataBinding
{
    public class Contact
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public Pays MonPays { get; set; }
        public static List<Contact> LoadContacts()
        {
            var LesContacts = new List<Contact>()
            {
                new Contact()
                {
                    Nom = "Nguyen",
                    Prenom = "Viet",
                    MonPays = new Pays() { Nom = "France" },
                    DateNaissance = Convert.ToDateTime("2019/12/12")
                },
                new Contact()
                {
                    Nom = "Kim",
                    Prenom = "Kabal",
                    MonPays = new Pays() { Nom = "Germany" },
                    DateNaissance = Convert.ToDateTime("2018/11/11")
                },
            };
            return LesContacts;
        }
    }
    public class Contacts
    {
        public List<Contact> ListeContact { get; set; }
        #region constructeur par default
        public Contacts()
        {

        }
        #endregion
        #region constructeur par default
        public Contacts(List<Contact> listContact)
        {
            ListeContact = listContact;
        }
        #endregion
    }
}
