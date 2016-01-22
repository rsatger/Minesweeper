using System;
using System.Runtime.Remoting;

namespace Minesweeper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting the game");
            Console.WriteLine();

            var board = new Board();
            Draw(board);

            while (!board.GameOver && board.CellsRevealed < board.Dimension)
            {
                var row = ReadInput("row");
                var col = ReadInput("column");

                Console.WriteLine();

                if (!board.TreatUserInput(row, col))
                    Console.WriteLine("This cell has already been cleared");

                Console.WriteLine();

                Draw(board);
                Console.WriteLine(board.GameOver ? "This is a mine..." : (board.Dimension - board.CellsRevealed + " Cells before victory"));
            }

            Console.WriteLine(board.GameOver ? "GameOver" : "You won !");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        internal static int ReadInput(string dim)
        {
            if (dim == null)
                throw new ArgumentNullException("dim");
            
            int dimNumber;

            Console.Write("Enter " + dim + ": ");

            if (!Int32.TryParse(Console.ReadLine(), out dimNumber))
            {
                Console.WriteLine("Please enter an integer");
                return ReadInput(dim);
            }
            if (dimNumber <= 0 || dimNumber > 10)
            {
                Console.WriteLine("Entry out of range, enter a value corresonding to a " + dim + " number");
                return ReadInput(dim);
            }
            return dimNumber;
        }

        public static void Draw(Board board)
        {
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");

            Console.WriteLine();

            for (int row = 0; row < board.NumRow; row++)
            {
                if (row + 1 < 10) Console.Write(row + 1 + "  ");
                else Console.Write(row + 1 + " ");

                for (int col = 0; col < board.NumCol; col++)
                {
                    if (board.Cells[row, col].Visibility == CellVisibility.Revealed)
                    {
                        if (board.Cells[row, col].IsMine)
                        {
                            Console.Write("M ");
                        }
                        else
                        {
                            Console.Write(board.Cells[row, col].MinesAround + " ");
                        }
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}