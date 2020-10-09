using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game");
            Console.WriteLine("=========================\n");
            TicTacToeGame game = new TicTacToeGame();
            game.CreateBoard();
            TicTacToeGame.player = game.DoToss();
            if (TicTacToeGame.player == TicTacToeGame.Player.User)
            {
                game.UserChooseLetter();
            }
            if (TicTacToeGame.player == TicTacToeGame.Player.Computer)
            {
                game.ComputerChooseLetter();
            }
            while (TicTacToeGame.end == false)
            {
                if (TicTacToeGame.player == TicTacToeGame.Player.User)
                {
                    game.UserMove();
                    game.WriteWinner();
                }
                if (TicTacToeGame.player == TicTacToeGame.Player.Computer)
                {
                    game.ComputerMove();
                    game.WriteWinner();
                }
            }
        }
    }
    
}

