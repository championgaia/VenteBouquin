using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Exo_Contacts
{
    public partial class EditionContact : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public EditionContact()
        {
            InitializeComponent();
            Contact = new Contact
            {
                DateNaissance = DateTime.Today.AddYears(-5)
            };
            DataContext = this;

            ListePays = App.Pays;
        }

        public ObservableCollection<Pays> ListePays { get; }

        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            private set
            {
                contact = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Contact)));
            }
        }

        public void ChargerContact(Contact contact)
        {
            Contact = contact;
            Title = "Edition d'un contact";
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            App.Contacts.Add(Contact);
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
