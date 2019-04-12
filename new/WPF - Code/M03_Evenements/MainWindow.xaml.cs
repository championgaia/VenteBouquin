using System.Windows;
using System.Windows.Controls;

namespace M03_Evenements
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            var bouton = e.OriginalSource as Button;
            if (bouton == null) return;

            MessageBox.Show($"{bouton.Content}: Click (Window)");
        }

        private void DockPanel_Click(object sender, RoutedEventArgs e)
        {
            var bouton = e.OriginalSource as Button;
            if (bouton == null) return;


            if ((string)bouton.Content == "Bouton 2")
            {
                MessageBox.Show($"{bouton.Content}: Click (DockPanel) - Traité");
                e.Handled = true;
            }
            else
                MessageBox.Show($"{bouton.Content}: Click (DockPanel)");
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            var bouton = e.OriginalSource as Button;
            if (bouton == null) return;

            MessageBox.Show($"{bouton.Content}: Click (Grid)");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var bouton = e.OriginalSource as Button;
            if (bouton == null) return;

            MessageBox.Show($"{bouton.Content}: Click -> traité");

            // On marque l'événement comme traité.
            //   Il ne remontera pas l'arbre visuel
            e.Handled = true;
        }
    }
}
