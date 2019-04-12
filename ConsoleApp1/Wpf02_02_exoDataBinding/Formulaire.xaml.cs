using System;
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
        }
        public Contact Contact { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContactViewModel contactFormulaire = new ContactViewModel
            {
                ContactM = new Contact()
                {
                    Nom = "",
                    Prenom = "",
                    DateNaissance = DateTime.UtcNow,
                    MonPays = new Pays()
                    {
                        Nom = ""
                    }
                }
            };
            this.Close();
        }
    }
}
