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
        public void GoToDesiredLocation()
        {
            Console.WriteLine("Enter you desired location between 1 and 9");
            int selectedLocation;
            int desiredLocation = Convert.ToInt32(Console.ReadLine());
            if ((desiredLocation <= 9) && (desiredLocation >= 1))
            {
                if (board[desiredLocation] == ' ')
                {
                    Console.WriteLine("Location " + desiredLocation + " Selected");
                    selectedLocation = desiredLocation;
                }
                else
                {
                    Console.WriteLine("Desired location is already filled\nTry Again");
                    GoToDesiredLocation();
                }
            }
            else
            {
                Console.WriteLine("Wrong Location\nTry Again");
                GoToDesiredLocation();
            }
        }
    }
}
