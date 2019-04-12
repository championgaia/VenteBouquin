using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Exo_Contacts
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListeContacts = App.Contacts;
            ListePays = App.Pays;
            DataContext = this;
        }

        public ObservableCollection<Contact> ListeContacts { get; set; }
        public ObservableCollection<Pays> ListePays { get; set; }

        // Ce code sera exécuté quand on cliquera sur le bouton associé
        private void AjouterContact_Click(object sender, RoutedEventArgs e)
        {
            var formulaireNouveauContact = new EditionContact();
            formulaireNouveauContact.ShowDialog();
        }

        // Idem
        private void AjouterPays_Click(object sender, RoutedEventArgs e)
        {
            var formulaireNouveauPays = new NouveauPays();
            formulaireNouveauPays.ShowDialog();
        }
    }
}
