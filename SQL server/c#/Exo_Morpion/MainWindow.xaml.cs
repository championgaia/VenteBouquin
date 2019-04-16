using Exo_Morpion.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Exo_Morpion
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Jeu = new Jeu();
            Jeu.NouvellePartie();
            this.DataContext = this;
        }

        public Jeu Jeu { get; set; }

        private void Case_Click(object sender, RoutedEventArgs e)
        {
            // On récupère dans le DataContext du bouton la case du plateau
            var button = (Button)e.Source;
            var casePlateau = (Case)button.DataContext;

            Jeu.PartieEnCours.JoueurEnCours.JouerCase(casePlateau);
        }

        private void NouvellePartie_Click(object sender, RoutedEventArgs e)
        {
            Jeu.NouvellePartie();
        }
    }
}
