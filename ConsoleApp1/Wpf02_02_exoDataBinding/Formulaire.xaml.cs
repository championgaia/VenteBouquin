using System.Windows;

namespace Wpf02_02_exoDataBinding
{
    /// <summary>
    /// Logique d'interaction pour Formulaire.xaml
    /// </summary>
    public partial class Formulaire : Window
    {
        public Formulaire()
        {
            InitializeComponent();
            Contact = new Contact();
        }
        public Contact Contact { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
