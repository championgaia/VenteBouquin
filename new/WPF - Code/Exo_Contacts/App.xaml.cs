using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Exo_Contacts
{
    public partial class App : Application
    {
        public static ObservableCollection<Pays> Pays { get; }
            = new ObservableCollection<Pays>
                {
                    new Pays{Nom="FRANCE"},
                    new Pays{Nom="ALLEMAGNE"},
                    new Pays{Nom="ESPAGNE"},
                    new Pays{Nom="ROYAUME-UNI"},
                    new Pays{Nom="ITALIE"},
                    new Pays{Nom="SUISSE"},
                    new Pays{Nom="BELGIQUE"},
                    new Pays{Nom="LUXEMBOURG"},
                    new Pays{Nom="ETATS-UNIS"},
                };

        public static ObservableCollection<Contact> Contacts { get; }
            = new ObservableCollection<Contact>
            {
                new Contact{
                    Nom = "PRESLEY",
                    Prenom = "Elvis",
                    DateNaissance = new DateTime(1977,8,16),
                    Pays = Pays.Single(x => x.Nom == "ETATS-UNIS")
                }
            };

    }
}
