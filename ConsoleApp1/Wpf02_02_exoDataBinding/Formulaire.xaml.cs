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
using System.Windows.Shapes;

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
