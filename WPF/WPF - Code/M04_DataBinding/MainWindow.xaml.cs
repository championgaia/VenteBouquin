using System.Windows;

namespace M04_DataBinding
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Personne = new Personne
            {
                Nom = "LALANNE",
                Prenom = "Francis"
            };
            DataContext = this;
        }

        public Personne Personne { get; set; }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            // On modifie les propriétés de Personne dans le code
            //  pour valider que les contrôles "bindés" sont mis à jour
            Personne.Nom = null;
            Personne.Prenom = null;
        }
    }
}
