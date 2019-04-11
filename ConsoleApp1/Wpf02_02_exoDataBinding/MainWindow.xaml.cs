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

namespace Wpf02_02_exoDataBinding
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LesContacts = Contact.LoadContacts();
            LesPays = Pays.LoadPays();
            DataContext = this;
        }
        public List<Contact> LesContacts { get; set; }
        public List<Pays> LesPays { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Formulaire();
            newWindow.Show();
            //var window = new Window1();
            //window.Show();
            //window.ShowDialog(); //comme modale html
            //window.Close();
        }
    }
}
