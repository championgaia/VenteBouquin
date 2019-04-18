using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exo_Morpion
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
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
