using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace tic_tac_toe
{
    /// <summary>
    /// Логика взаимодействия для AIMode.xaml
    /// </summary>
    public partial class AIMode : Window
    {
        public bool isHumanMove;
        public AIMode()
        {
            InitializeComponent();
            NewGame();
        }
        /// <summary>
        /// Hold the current moves in active game
        /// </summary>
        private TypeOfMark[] currentMoves;

        private bool turnOver = false;

        private bool isGameEnded;

        //public Button[]  AiLogic()
        //{

        //    Button[] buttons = { Button0_0, Button0_1, Button0_2, Button1_0, Button1_1, Button1_2, Button2_0, Button2_1, Button2_2 };
        //    return buttons;

        //}


    private void NewGame()
        {
            currentMoves = new TypeOfMark[9];
            for (var i = 0; i < currentMoves.Length; i++)
            {
                currentMoves[i] = TypeOfMark.Free;
            }

            ContainerAI.Children.Cast<Button>().ToList().ForEach(button_ai =>
            {
                button_ai.Content = string.Empty;
            });
            isGameEnded = false;
        }

        private void Button_Click_AI(object sender, RoutedEventArgs e)
        {
            if (isGameEnded)
            {
                NewGame();
                Close();
                return;
            }

            var button_ai = (Button)sender;

            var column = Grid.GetColumn(button_ai);
            var row = Grid.GetRow(button_ai);

            var index = column + (row * 3);

            if (currentMoves[index] != TypeOfMark.Free)
            {
                return;
            }

            if (isHumanMove)
            {
                currentMoves[index] = TypeOfMark.Cross;
                button_ai.Content = 'X';
            }
            else
            {
                currentMoves[index] = TypeOfMark.Nought;
                button_ai.Content = 'O';
            }

            CheckForWinner();
            AiMove();

        }
        private void AiMove()
        {
            int[] best_ai_moves = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };
            Button[] buttons = { Button0_0, Button0_1, Button0_2, Button1_0, Button1_1, Button1_2, Button2_0, Button2_1, Button2_2 };
            int j = 0;
            for (int i = 0; i < best_ai_moves.Length; i++)
            {
                if (currentMoves[best_ai_moves[i]] == TypeOfMark.Free)
                {
                    if (isHumanMove)
                    {
                        buttons[best_ai_moves[i]].Content = "O";
                        currentMoves[best_ai_moves[i]] = TypeOfMark.Nought;
                    }

                    else
                    {
                        buttons[best_ai_moves[i]].Content = "X";
                        currentMoves[best_ai_moves[i]] = TypeOfMark.Cross;
                    }
                    break;
                }
            }
            CheckForWinner();

        }
        private void CheckForWinner()
        {
            var same = (currentMoves[0] & currentMoves[1] & currentMoves[2]) == currentMoves[0];
            if (currentMoves[0] != TypeOfMark.Free && same)
            {
                isGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.BlueViolet;
            }
            var same1 = (currentMoves[3] & currentMoves[4] & currentMoves[5]) == currentMoves[3];
            if (currentMoves[3] != TypeOfMark.Free && same1)
            {
                isGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.BlueViolet;
            }
            var same2 = (currentMoves[6] & currentMoves[7] & currentMoves[8]) == currentMoves[6];
            if (currentMoves[6] != TypeOfMark.Free && same2)
            {
                isGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.BlueViolet;
            }

            var same3 = (currentMoves[0] & currentMoves[3] & currentMoves[6]) == currentMoves[0];
            if (currentMoves[0] != TypeOfMark.Free && same3)
            {
                isGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.BlueViolet;
            }
            var same4 = (currentMoves[1] & currentMoves[4] & currentMoves[7]) == currentMoves[1];
            if (currentMoves[1] != TypeOfMark.Free && same4)
            {
                isGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.BlueViolet;
            }
            var same5 = (currentMoves[2] & currentMoves[5] & currentMoves[8]) == currentMoves[2];
            if (currentMoves[2] != TypeOfMark.Free && same5)
            {
                isGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.BlueViolet;
            }
            var same6 = (currentMoves[0] & currentMoves[4] & currentMoves[8]) == currentMoves[0];
            if (currentMoves[0] != TypeOfMark.Free && same6)
            {
                isGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.BlueViolet;
            }
            var same7 = (currentMoves[2] & currentMoves[4] & currentMoves[6]) == currentMoves[2];
            if (currentMoves[2] != TypeOfMark.Free && same7)
            {
                isGameEnded = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.BlueViolet;
            }

            if (!currentMoves.Any(result => result == TypeOfMark.Free))
            {
                isGameEnded = true;
                ContainerAI.Children.Cast<Button>().ToList().ForEach(button_ai =>
                {
                    button_ai.Background = Brushes.OrangeRed;
                });
            }
        }

    }
}

