using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array to the Store the Board
            char[,] board = new char[3, 3];
            // Coordinates of row and column of field in board
            int row = 0;
            int column = 0;
            // Used to convert users unput 1-9 into row and column on board
            int[] Coordinates = new int[2];
            // Used to switch the players symbol and decide, who won
            string CurrentPlayer = "Player2";
            string NextPlayer = "Player1";
            // Stores the current players symbol
            char Symbol = ' ';
            // Flag if game is still running
            bool GameRunning = true;
            // Used to Check if the game is a draw 
            int TurnCount = 0;
            // Stores what State the Game ended with | Win/Draw
            string State = "";
            InitBoard(board);
            ShowRules();
            ShowBoard(board);

            // Main game loop
            while (GameRunning != false)
            {
                SwitchPlayerTurn(ref CurrentPlayer, ref NextPlayer);
                // take users input and convert it to row and column coordinates
                Console.WriteLine("Where do you want to Place your Symbol? Please input 1(top left) to 9(bottom right): ");
                int Location = Convert.ToInt16(Console.ReadLine());
                while (GetCoordinates(Location, Coordinates) != true)
                {
                    Console.WriteLine("Where do you want to Place your Symbol? Please input 1(top left) to 9(bottom right): ");
                    Location = Convert.ToByte(Console.ReadLine());
                }
                row = Coordinates[0];
                column = Coordinates[1];
                // set the current players symbol
                if (CurrentPlayer == "Player1")
                {
                    Symbol = 'X';
                }
                else
                {
                    Symbol = 'O';
                }
                InsertSymbol(Symbol, board, row, column);
                CheckState(board, Symbol, ref State, ref GameRunning);
                // At end of Turn
                Console.Clear();
                ShowBoard(board);
                // Check if an Draw occured
                TurnCount++;
                if (TurnCount >= 9 && GameRunning == true)
                {
                    State = "Draw";
                    GameRunning = false;
                }
            }
            if (State == "Won")
            {
                Console.WriteLine("Congratulation " + CurrentPlayer + " you have won!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Draw");
                Console.ReadLine();
            }
        }

        // inits the board with values
        static void InitBoard(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    // seems like chars need '' instead of ""
                    board[row, col] = ' ';
                }
            }
        }

        // Show the rules befor the game beginns
        static void ShowRules()
        {
            Console.WriteLine("Welcome to TicTacToe!");
            Console.WriteLine("The game is for 2 Players, who play on a 3x3 board");
            Console.WriteLine("The Players alternately choose a field to insert their Symbol, a X or an O");
            Console.WriteLine("Goal of the game is to be the first with 3 Symbols in a row");
            Console.WriteLine("This can be done horizontal, vertical or diagonally");
        }

        // Print the Board in an easy to read form
        static void ShowBoard(char[,] board)
        {
            Console.WriteLine(" " + board[0, 0] + " | " + board[1, 0] + " | " + board[2, 0] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[0, 1] + " | " + board[1, 1] + " | " + board[2, 1] + " ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[0, 2] + " | " + board[1, 2] + " | " + board[2, 2] + " ");
        }

        static bool GetCoordinates(int location, int[] Coordinates)
        {
            switch (location)
            {
                case 1:
                    Coordinates[0] = 0;
                    Coordinates[1] = 0;
                    return true;
                //return Coordinates;
                case 2:
                    Coordinates[0] = 1;
                    Coordinates[1] = 0;
                    return true;
                //return Coordinates;
                case 3:
                    Coordinates[0] = 2;
                    Coordinates[1] = 0;
                    return true;
                //return Coordinates;
                case 4:
                    Coordinates[0] = 0;
                    Coordinates[1] = 1;
                    return true;
                //return Coordinates;
                case 5:
                    Coordinates[0] = 1;
                    Coordinates[1] = 1;
                    return true;
                //return Coordinates;
                case 6:
                    Coordinates[0] = 2;
                    Coordinates[1] = 1;
                    return true;
                //return Coordinates;
                case 7:
                    Coordinates[0] = 0;
                    Coordinates[1] = 2;
                    return true;
                //return Coordinates;
                case 8:
                    Coordinates[0] = 1;
                    Coordinates[1] = 2;
                    return true;
                //eturn Coordinates;
                case 9:
                    Coordinates[0] = 2;
                    Coordinates[1] = 2;
                    return true;
                //return Coordinates;
                default:
                    return false;
            }

        }

        // Inserts the Players Symbol into the Board
        static void InsertSymbol(char Symbol, char[,] board, int row, int column)
        {
            board[row, column] = Symbol;
        }

        // Switches which Player has the next turn
        static void SwitchPlayerTurn(ref string CurrentPlayer, ref string NextPlayer)
        {
            if (CurrentPlayer == "Player1")
            {
                CurrentPlayer = "Player2";
                NextPlayer = "Player1";
            }
            else
            {
                CurrentPlayer = "Player1";
                NextPlayer = "Player2";
            }
        }
        static void CheckState(char[,] board, char Symbol, ref string State, ref bool GameRunning)
        {
            // Check Vertical
            if (Symbol == board[0, 0] && Symbol == board[1, 0] && Symbol == board[2, 0] || Symbol == board[0, 1] && Symbol == board[1, 1] && Symbol == board[2, 1] || Symbol == board[0, 2] && Symbol == board[1, 2] && Symbol == board[2, 2])
            {
                State = "Won";
                GameRunning = false;
            }

            // Check Horizontal
            else if (Symbol == board[0, 0] && Symbol == board[1, 0] && Symbol == board[2, 0] || Symbol == board[0, 1] && Symbol == board[1, 1] && Symbol == board[2, 1] || Symbol == board[0, 2] && Symbol == board[1, 2] && Symbol == board[2, 2])
            {
                State = "Won";
                GameRunning = false;
            }

            // Check diagonally
            else if (Symbol == board[0, 0] && Symbol == board[1, 1] && Symbol == board[2, 2] || Symbol == board[0, 2] && Symbol == board[1, 1] && Symbol == board[2, 0])
            {
                State = "Won";
                GameRunning = false;
            }
        }
    }
}
