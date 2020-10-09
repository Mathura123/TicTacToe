using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game");
            TicTacToeGame game = new TicTacToeGame();
            game.CreateBoard();
            TicTacToeGame.player = game.DoToss();
            if(TicTacToeGame.player == TicTacToeGame.Player.User)
            {
                game.UserChooseLetter();
            }
            if(TicTacToeGame.player==TicTacToeGame.Player.Computer)
            {
                game.ComputerChooseLetter();
            }
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
            game.ComputerMove();
            game.WriteWinner();
            game.UserMove();
            game.WriteWinner();
        }
    }
    
}

