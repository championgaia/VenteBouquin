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
            DataContext = this;
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
    }
}
