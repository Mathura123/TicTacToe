using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
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
        EnterKey:
            Console.WriteLine("\nEnter :  1 to play once more");
            Console.WriteLine("Enter :  2 to Exit");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    TicTacToeGame.end = false;
                    TicTacToe.Program.Main();
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Wrong key\nTry Once Again");
                    goto EnterKey;
                    break;
            }
        }
    }
}

