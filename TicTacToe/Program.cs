using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game");
        }
    }
    class TicTacToeGame
    {
        public char[] board = new char[10];
        public void Board()
        {
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = '';
            }
        }
    }
}

