using System;

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

            while (!board.GameOver) //todo check number of cells left to reveal
            {
                var row = ReadRow();
                var col = ReadColumn();
                
                Console.WriteLine();
                
                if (!board.TreatUserInput(row, col))
                    Console.WriteLine("This cell has already been cleared");
                
                Console.WriteLine();

                Draw(board);
            }

            Console.WriteLine(board.GameOver ? "GameOver" : "You won !");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        private static int ReadColumn()
        {
            int col;

            Console.Write("Enter column: ");

            if (Int32.TryParse(Console.ReadLine(), out col))
            {
                // to do: exception handling
            }
            return col;
        }

        private static int ReadRow()
        {
            int row;
            Console.Write("Enter row: ");

            if (Int32.TryParse(Console.ReadLine(), out row))
            {
                // to do: exception handling
            }
            return row;
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
            //Console.WriteLine(cellsRevealed + " cells cleared");
            Console.WriteLine();
        }
    }
}