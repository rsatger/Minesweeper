using System;

namespace Minesweeper
{
    internal class Program
    {
        public static void Main(string[] args) // use to be private static void Main(string[] args)
        {
            
            var log = new Log();
            var com = new Communicator();
            var interact = new Interactivity(com, log);

            com.Write(MessageResources.GameStart + Environment.NewLine, log);
            
            var board = new Board(com);
            Draw(board);

            while (!board.GameOver && board.CellsRevealed < board.Dimension)
            {
                board.PlayCell(interact.GetValidIndex(DimensionType.Row), interact.GetValidIndex(DimensionType.Column));

                //Console.WriteLine();

                Draw(board);
                com.Write(board.GameOver ? MessageResources.ThisIsMine : (board.Dimension - board.CellsRevealed + MessageResources.CellsBeforeVictory), log);
            }

            com.Write(board.GameOver ? MessageResources.GameOver : MessageResources.YouWon, log);
            com.Write(MessageResources.PressKeyExit, log);
            com.Read(log);
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