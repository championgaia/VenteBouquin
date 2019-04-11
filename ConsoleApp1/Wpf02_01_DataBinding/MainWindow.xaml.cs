using System.Windows;

namespace Wpf02_01_DataBinding
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Personne = new Personne
            {
                Nom = "Nguyen",
                Prenom = "Viet"
            };
            DataContext = this; //on peut mettre Personne
        }
        //propriete simplifier C#
        //public string Nom { get; set; }
        //syntax complete
        public Personne Personne { get; set; }
        private string _nom1;
        public string Nom1
        {
            get { return _nom1; }
            set { _nom1 = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Personne.Nom = null;
            Personne.Prenom = null;

        }
    }
}
