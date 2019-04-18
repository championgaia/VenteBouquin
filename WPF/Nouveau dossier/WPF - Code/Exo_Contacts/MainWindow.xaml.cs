using System.Windows;

namespace Exo_Contacts
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AjouterContact_Click(object sender, RoutedEventArgs e)
        {
            var formulaireNouveauContact = new EditionContact();
            formulaireNouveauContact.ShowDialog();
        }

        private void AjouterPays_Click(object sender, RoutedEventArgs e)
        {
            var formulaireNouveauPays = new NouveauPays();
            formulaireNouveauPays.ShowDialog();
        }
    }
}
