using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        static char[] board = new char[10];
        private int size = Convert.ToInt32(Math.Sqrt(board.Length));
        private string winner;
        public static bool end;
        public enum Player { User, Computer };
        private Dictionary<Player, char> playersChoice = new Dictionary<Player, char>();
        public static Player player;
        public void CreateBoard()
        {
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = ' ';
            }
        }
        public Player DoToss()
        {
            Random random = new Random();
            int toss = random.Next(2);
            if (toss == 0)
            {
                Console.WriteLine("Computer ==> Start");
                player = Player.Computer;
            }
            else
            {
                Console.WriteLine("User ==> Start");
                player = Player.User;
            }
            return player;
        }
        public void ShowBoard()
        {
            for (int i = 1; i < board.Length; i++)
            {
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
            Console.WriteLine("\n");
        }
        public void UserChooseLetter()
        {
            Console.WriteLine("Enter your letter X or O");
            char choice = Convert.ToChar(Console.ReadLine());
            if ((char.ToUpper(choice) == 'X') || (char.ToUpper(choice) == 'O'))
            {
                choice = char.ToUpper(choice);
                Console.WriteLine("User ==> " + choice);
                playersChoice[Player.User] = choice;
                if (choice == 'X')
                {
                    playersChoice[Player.Computer] = 'O';
                }
                else
                {
                    playersChoice[Player.Computer] = 'X';
                }
                Console.WriteLine("Computer ==> " + playersChoice[Player.Computer]);
            }
            else
            {
                Console.WriteLine("Incorrect letter\nTry once more");
                UserChooseLetter();
            }
        }
        public void ComputerChooseLetter()
        {
            Random random = new Random();
            int letterIndex = random.Next(2);
            switch (letterIndex)
            {
                case 0:
                    playersChoice.Add(Player.Computer, 'X');
                    playersChoice.Add(Player.User, 'O');
                    break;
                case 1:
                    playersChoice.Add(Player.User, 'O');
                    playersChoice.Add(Player.Computer, 'X');
                    break;
            }
            Console.WriteLine("User ==> " + playersChoice[Player.User]);
            Console.WriteLine("Computer ==> " + playersChoice[Player.Computer]);
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
                if (IsSpace(desiredLocation) == true)
                {
                    MakeMove(playersChoice[Player.User], desiredLocation);
                    if (IsWin() == true)
                    {
                        winner = Convert.ToString(Player.User);
                    }
                    DetermineGameSituation(Player.User);
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
        private bool WinningMove()
        {
            bool winningMove = false;
            for (int i = 1; i < board.Length; i++)
            {
                if (IsSpace(i) == true)
                {
                    MakeMove(playersChoice[Player.Computer], i);
                    if (IsWin() == true)
                    {
                        winningMove = true;
                        break;
                    }
                    else
                    {
                        board[i] = ' ';
                    }
                }
            }
            return winningMove;
        }
        private bool BlockingMove()
        {
            bool blockingMove = false;
            for (int i = 1; i < board.Length; i++)
            {
                if (IsSpace(i) == true)
                {
                    MakeMove(playersChoice[Player.User], i);
                    if (IsWin() == true)
                    {
                        MakeMove(playersChoice[Player.Computer], i);
                        blockingMove = true;
                        break;
                    }
                    else
                    {
                        board[i] = ' ';
                    }
                }
            }
            return blockingMove;
        }
        private bool CornerMove()
        {
            bool cornerMove = false;
            if (board[1] == ' ')
            {
                cornerMove = true;
                MakeMove(playersChoice[Player.Computer], 1);
            }
            else if (board[size] == ' ')
            {
                cornerMove = true;
                MakeMove(playersChoice[Player.Computer], size);
            }
            else if (board[7] == ' ')
            {
                cornerMove = true;
                MakeMove(playersChoice[Player.Computer], 7);
            }
            else if (board[9] == ' ')
            {
                cornerMove = true;
                MakeMove(playersChoice[Player.Computer], 9);
            }
            return cornerMove;
        }
        private bool CentralOrEdgeMove()
        {
            bool centralOrEdgeMove = false;
            if (board[5] == ' ')
            {
                MakeMove(playersChoice[Player.Computer], 5);
                centralOrEdgeMove = true;
            }
            else
            {
                if (board[2] == ' ')
                {
                    MakeMove(playersChoice[Player.Computer], 2);
                    centralOrEdgeMove = true;
                }
                else if (board[4] == ' ')
                {
                    MakeMove(playersChoice[Player.Computer], 4);
                    centralOrEdgeMove = true;
                }
                else if (board[6] == ' ')
                {
                    MakeMove(playersChoice[Player.Computer], 6);
                    centralOrEdgeMove = true;
                }
                else if (board[8] == ' ')
                {
                    MakeMove(playersChoice[Player.Computer], 8);
                    centralOrEdgeMove = true;
                }
            }
            return centralOrEdgeMove;
        }
        public void ComputerMove()
        {
            bool winningMove = WinningMove();

            if (winningMove == true)
            {
                winner = Convert.ToString(Player.Computer);
            }
            if (winningMove == false)
            {
                bool blockingMove = BlockingMove();
                if (blockingMove == false)
                {
                    bool cornerMove = CornerMove();
                    if (cornerMove == false)
                    {
                        bool centralOrEdgeMove = CentralOrEdgeMove();
                        if (centralOrEdgeMove == false)
                        {
                            for (int i = 1; i < board.Length; i++)
                            {
                                if (IsSpace(i) == true)
                                {
                                    MakeMove(playersChoice[Player.Computer], i);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            DetermineGameSituation(Player.Computer);
        }
        public void DetermineGameSituation(Player currentPlayer)
        {
            if (IsWin() == false)
            {
                if (IsTie() == false)
                    ChangeTurn(currentPlayer);
            }
            ShowBoard();
        }
        public bool IsWin()
        {
            if (CompareRowWise() == true)
            {
                return true;
            }
            else if (CompareColumnWise() == true)
            {
                return true;
            }
            else if (CompareDiagonalWise() == true)
            {
                return true;
            }
            else
                return false;
        }
        private bool IsTie()
        {
            bool tie = true;
            for (int i = 1; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    tie = false;
                    break;
                }
            }
            winner = "Tie";
            return tie;
        }
        private bool CompareRowWise()
        {
            bool win = false;
            for (int i = 1; i < board.Length; i = i + size)
            {
                for (int j = i + 1; j < size + i; j++)
                {
                    if ((board[j] == board[i]) && (board[i] != ' '))
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win == true)
                {
                    return win;
                }
            }
            return win;
        }
        private bool CompareColumnWise()
        {
            bool win = false;
            for (int i = 1; i <= size; i++)
            {
                for (int j = i + size; j < (board.Length); j += size)
                {
                    if ((board[j] == board[i]) && (board[j] != ' '))
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win == true)
                {
                    return win;
                }
            }
            return win;
        }
        private bool CompareDiagonalWise()
        {
            bool win = false;
            for (int i = 1, lineNo = 2; i < board.Length && lineNo <= size; i += size, lineNo++)
            {
                if ((board[i + lineNo + size - 1] == board[1]) && (board[1] != ' '))
                {
                    win = true;
                }
                else
                {
                    win = false;
                    break;
                }
            }
            if (win == true)
            {
                return win;
            }
            for (int i = size, lineNo = 2; i < board.Length && lineNo <= 3; i += size, lineNo++)
            {
                if (board[i - lineNo + size + 1] == board[size] && (board[size] != ' '))
                {
                    win = true;
                }
                else
                {
                    win = false;
                    break;
                }
            }
            if (win == true)
            {
                return win;
            }
            return win;
        }
        private void ChangeTurn(Player currentPlayer)
        {
            if (currentPlayer == Player.Computer)
            {
                player = Player.User;
            }
            else
                player = Player.Computer;
        }
        public void WriteWinner()
        {
            if (IsWin() == true)
            {
                Console.WriteLine("Winner is " + winner + "\n");
                end = true;

            }
            else if (IsTie() == true)
            {
                Console.WriteLine("The Game is Tied\n");
                end = true;
            }
        }
    }
}
