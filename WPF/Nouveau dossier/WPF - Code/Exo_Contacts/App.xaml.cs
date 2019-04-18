using System.Collections.Generic;
using System.Windows;

namespace Exo_Contacts
{
    public partial class App : Application
    {
        public static List<Pays> Pays { get; }
            = new List<Pays>
                {
                    new Pays{Nom="FRANCE"},
                    new Pays{Nom="ALLEMAGNE"},
                    new Pays{Nom="ESPAGNE"},
                    new Pays{Nom="ROYAUME-UNI"},
                    new Pays{Nom="ITALIE"},
                    new Pays{Nom="SUISSE"},
                    new Pays{Nom="BELGIQUE"},
                    new Pays{Nom="LUXEMBOURG"}
                };

        public static List<Contact> Contacts { get; } 
            = new List<Contact>();

    }
}
