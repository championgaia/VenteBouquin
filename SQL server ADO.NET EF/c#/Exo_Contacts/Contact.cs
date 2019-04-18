using System;
using System.ComponentModel;

namespace Exo_Contacts
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private Pays pays;

        public string Nom
        {
            get { return nom; }
            set
            {
                if (nom != value)
                {
                    nom = value;
                    RaisePropertyChanged(nameof(Nom));
                }
            }
        }

        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (prenom != value)
                {
                    prenom = value;
                    RaisePropertyChanged(nameof(Prenom));
                }
            }
        }

        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set
            {
                if (dateNaissance != value)
                {
                    dateNaissance = value;
                    RaisePropertyChanged(nameof(DateNaissance));
                }
            }
        }

        public Pays Pays
        {
            get { return pays; }
            set
            {
                if (pays != value)
                {
                    pays = value;
                    RaisePropertyChanged(nameof(Pays));
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            // On déclenche l'événement pour notifier les abonnés (uniquement s'il y en a)
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
