using System;
using System.ComponentModel;
using System.Windows;

namespace Exo_Contacts
{
    public partial class NouveauPays : Window
    {
        public NouveauPays()
        {
            InitializeComponent();
            Pays = new Pays();
            DataContext = this;
        }

        // Cette méthode est appelée quand la fenêtre est activée (affichée)
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Je donne le focus au textbox de saisie du nom de pays
            tbNomPays.Focus();
        }

        public Pays Pays { get; set; }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            App.Pays.Add(Pays);
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
