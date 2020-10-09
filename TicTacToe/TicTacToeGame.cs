using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        char[] board = new char[10];
        char choice;

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
            choice = Convert.ToChar(Console.ReadLine());
            if ((char.ToUpper(choice) == 'X') || (char.ToUpper(choice) == 'O'))
            {
                Console.WriteLine("Your choice is " + char.ToUpper(choice));
                choice = char.ToUpper(choice);
            }
            else
            {
                Console.WriteLine("Incorrect letter\nTry once more");
                ChooseLetter();
            }
        }
        public void ShowBoard()
        {
            for (int i = 1; i < board.Length; i++)
            {
                int size = Convert.ToInt32(Math.Sqrt(board.Length));
                Console.Write(" " + board[i]);
                if ((i % size) != 0)
                {
                    Console.Write(" |");
                }
                if ((i % size) == 0)
                {
                    Console.WriteLine("\n---|---|---");
                }
            }
        }
        private bool IsSpace(int location)
        {
            return board[location] == ' ';
        }
        private void MakeMove(char choice, int location)
        {
            board[location] = choice;
        }
        public void UserMove()
        {
            Console.WriteLine("Enter you desired location between 1 and 9");
            int desiredLocation = Convert.ToInt32(Console.ReadLine());
            if ((desiredLocation <= 9) && (desiredLocation >= 1))
            {
                if (IsSpace(desiredLocation)==true)
                {
                    MakeMove(choice, desiredLocation);
                }
                else
                {
                    Console.WriteLine("Desired location is already filled\nTry Again");
                    UserMove();
                }
            }
            else
            {
                Console.WriteLine("Wrong Location\nTry Again");
                UserMove();
            }
        }
    }
}
