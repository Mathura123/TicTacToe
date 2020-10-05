using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        char[] board = new char[10];

        public void CreateBoard()
        {
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }
        public void ChooseLetter()
        {
            Console.WriteLine("Enter your letter X or O");
            char choice = Convert.ToChar(Console.ReadLine());
            if((choice == 'X') || (choice =='O'))
            {
                Console.WriteLine("Your choice is " +choice);
            }
            else
            {
                Console.WriteLine("Incorrect letter\n Try once more");
                ChooseLetter();
            }
        }
    }
}
