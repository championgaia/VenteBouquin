using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Exo_Morpion
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Joueur.Text = "O";
        }

        private void ChangerJoueur()
        {
            if (Joueur.Text == "O")
                Joueur.Text = "X";
            else
                Joueur.Text = "O";

            // Equivalent
            //Joueur.Text = Joueur.Text == "O" ? "X" : "O";
        }

        private void DockPanel_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)e.OriginalSource;
            if (button.Content == null
                || button.Content.ToString() == "")
            {
                button.Content = Joueur.Text;
                ChangerJoueur();
            }
        }

        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var button = (Button)e.Source;
            if (string.IsNullOrEmpty(button.Content?.ToString()))
            {
                MessageBox.Show("Mauvaise case");
                e.Handled = true;
            }
        }
    }
}
