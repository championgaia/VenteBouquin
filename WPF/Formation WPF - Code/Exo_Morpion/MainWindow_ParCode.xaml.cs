using System.Windows.Controls;

namespace Exo_Morpion
{
    public partial class MainWindow_ParCode
    {
        public MainWindow_ParCode()
        {
            InitializeComponent();

            // On charge les boutons à l'instanciation de la fenêtre
            LoadButtons();
        }

        private void LoadButtons()
        {
            var rowsCount = Grille.RowDefinitions.Count;
            var colsCount = Grille.ColumnDefinitions.Count;

            for (var row = 0; row < rowsCount; row++)
                for (var col = 0; col < colsCount; col++)
                {
                    var button = new Button();
                    button.SetValue(Grid.RowProperty, row);
                    button.SetValue(Grid.ColumnProperty, col);
                    button.Content = "O";
                    Grille.Children.Add(button);
                }
        }
    }
}
