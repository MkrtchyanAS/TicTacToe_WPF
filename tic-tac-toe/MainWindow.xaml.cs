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

namespace tic_tac_toe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool twoPlayersGame = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AIMode new_game_ai_x = new AIMode
            {
                isHumanMove = false
            };
            new_game_ai_x.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AIMode new_game_ai_o = new AIMode
            {
                isHumanMove = true
            };
            new_game_ai_o.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Field new_game = new Field();
            new_game.Show();
            twoPlayersGame = true;
        }
    }
}
