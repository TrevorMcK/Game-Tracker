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

namespace GAME_TRACKER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess data = new DataAccess();
            List<Game> game = data.Game();
            uxGamesGrid.ItemsSource = data.Game();
        }

        public void UxAddGame_Click(object sender, RoutedEventArgs e)
        {
            DataAccess data = new DataAccess();
            List<Game> game = data.Game();

            data.writeGame(game.Count + 2,uxGameName.Text,uxSystemPlayed.Text, Int32.Parse(uxYearPlayed.Text));

            uxGamesGrid.ItemsSource = data.Game();
        }

        public void UxGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
