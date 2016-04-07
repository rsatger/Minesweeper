using System;
using Minesweeper.Logs;

namespace Minesweeper
{
    internal class Program
    {
        public static void Main(string[] args) // use to be private static void Main(string[] args)
        {
            var com = new Communicator();
            var interact = new Interactivity(com);

            com.WriteLine(MessageResources.GameStart + Environment.NewLine);
            
            var board = new Board(com);
            Draw(board);

            while (!board.GameOver && board.CellsRevealed < board.TotalCellCount)
            {
                board.PlayCell(interact.GetValidIndex(DimensionType.Row), interact.GetValidIndex(DimensionType.Column));

                //Console.WriteLine();

                Draw(board);
                com.WriteLine(board.GameOver ? MessageResources.ThisIsMine : (board.TotalCellCount - board.CellsRevealed + MessageResources.CellsBeforeVictory));
            }

            com.WriteLine(board.GameOver ? MessageResources.GameOver : MessageResources.YouWon);
            com.WriteLine(MessageResources.PressKeyExit);
            com.Read();
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