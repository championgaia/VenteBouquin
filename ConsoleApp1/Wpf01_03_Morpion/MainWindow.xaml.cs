using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf01_03_Morpion
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadButtons();
            Joueur.Text = "O";
        }
        #region LoadButtons
        private void LoadButtons()
        {
            int count = 1;
            for (int i = 0; i < Grille.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < Grille.ColumnDefinitions.Count; j++)
                {
                    var button = new Button
                    {
                        FontSize = 50,
                        Content = "btn" + count.ToString()
                    };
                    button.Click += Btn_click;
                    button.SetValue(Grid.RowProperty, i);
                    button.SetValue(Grid.ColumnProperty, j);
                    Grille.Children.Add(button);
                    count++;
                }
            }

        }
        #endregion
        #region ChangerJoueur
        private void ChangerJoueur()
        {
            Joueur.Text = Joueur.Text == "O" ? "X" : "O";
        }
        #endregion
        #region Btn_click
        private void Btn_click(object sender, RoutedEventArgs e)
        {
            var myButton = (Button)sender;
            if ((string)myButton.Content == "O"|| (string)myButton.Content == "X")
                MessageBox.Show("btn verrouiller, choisir un autre");
            else
            {
                //Resources["myStr"] = "vide";
                string lastChoix = FindResource("myStr").ToString();
                if (lastChoix == "vide")
                {
                    myButton.Content = "X";
                    Resources["myStr"] = "X";
                    //lastChoix = "X";
                }
                else if (lastChoix == "O")
                {
                    myButton.Content = "X";
                    Resources["myStr"] = "X";
                    //lastChoix = "X";
                }
                else
                {
                    myButton.Content = "O";
                    Resources["myStr"] = "O";
                    //lastChoix = "O";
                };
                ChangerJoueur();
            }
        }
        #endregion
        #region DetectJoueurGagne
        public void DetectJoueurGagne()
        {




        }
        #endregion
        private void DockPanel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
