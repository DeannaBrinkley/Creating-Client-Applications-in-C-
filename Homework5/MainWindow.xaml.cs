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

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static char previousClick = ' ';
        int i, j;
        static char[,] board = new char[3,3];
        Button button;
        string tag;
        public MainWindow()
        {
            InitializeComponent();
            clearBoard();
        }

        private void clearBoard()
        {
            previousClick = ' ';
            // clear the board array
            for (i = 0; i < 9; i++)
            {
                button = (Button)uxGrid.Children[i];
                button.Content = ' ';
            }
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // use the button's tag to determine which space on the board the user clicked            
            button = (Button)sender;
            tag = button.Tag.ToString();
            i = (int)tag[0] - 48;
            j = (int)tag[2] - 48;
            // if that space on the board was empty, update it and check for Bingo
            if (board[i, j] == ' ')
            {
                if (previousClick == ' ' || previousClick == 'O')
                {
                    previousClick = 'X';
                    button.Content = 'X';
                }
                else
                {
                    previousClick = 'O';
                    button.Content = 'O';
                }
                board[i, j] = previousClick;
                checkForBingo();
            }
            else
            // if that space on the board was not empty, give an error message
                MessageBox.Show("Sorry, that space is already taken.");
        }

        private void checkForBingo()
        {
            bool bingoFound = false;
            char winner = ' ';
            // check for horizontal Bingo
            for (i = 0; i < 3; i++)
            {
                if (board[i,0] == board[i,1] && board[i, 1] == board[i,2] &&
                    board[i,0] != ' ')
                {
                    bingoFound = true;
                    winner = board[i, 0];
                    break;
                }
            }
            // check for vertical Bingo
            if (bingoFound == false)
            {
                for (j = 0; j < 3; j++)
                {
                    if (board[0,j] == board[1, j] && board[1, j] == board[2, j] &&
                        board[0, j] != ' ')
                    {
                        bingoFound = true;
                        winner = board[0,j];
                        break;
                    }
                }
            }
            // check for diagonal Bingo
            if (bingoFound == false)
            {
                if (((board[0, 0] != ' ') && (board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2])) ||
                    ((board[0, 2] != ' ') && (board[0, 2] == board[1, 1]) && (board[1, 1] == board[2, 0])))
                {
                    bingoFound = true;
                    winner = board[1,1];
                }
            }
            // if Bingo was found, tell the players who won and set up board for next game
            if (bingoFound == true)
            {
                MessageBox.Show("Bingo! " + winner.ToString() + " is the winner!");
                //MessageBox.Show("Submitting password:" + uxPassword.Text.Length);
                clearBoard();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            clearBoard();
        }
    }
}
