using System;

namespace Minesweeper
{
    public class Game
    {
        public int NumCol;

        public int NumRow;

        public Cell[,] game;

        public int CellsRevealed;

        public bool GameOver; // to use

        public Game()
        {
            NumCol = 10;
            NumRow = 10;
            GameOver = false;

            game = new Cell[NumRow, NumCol];
            var mines = InitializeMines(NumRow, NumCol);

            for (int row = 0; row < NumRow; row++)
                for (int col = 0; col < NumCol; col++)
                {
                    game[row, col] = new Cell(row, col, mines[row, col]);
                }
        }

        private static bool[,] InitializeMines(int maxRow, int maxCol)
        {
            var mines = new bool[maxRow, maxCol];
            mines[3, 1] = true;
            mines[1, 2] = true;
            mines[6, 2] = true;
            mines[6, 8] = true;
            mines[9, 9] = true;
            mines[4, 6] = true;
            mines[9, 2] = true;
            mines[6, 1] = true;
            mines[2, 7] = true;
            mines[9, 7] = true;
            return mines;
        }

        public void Play()
        {
            int row;
            int col;

            Console.Write("Enter row: ");

            if (Int32.TryParse(Console.ReadLine(), out row))
            {
                // to do: exception handling
            }

            Console.Write("Enter column: ");

            if (Int32.TryParse(Console.ReadLine(), out col))
            {
                // to do: exception handling
            }

            Console.WriteLine();

            if (game[row - 1, col - 1].Visibility != CellVisibility.Revealed)
            {
                game[row - 1, col - 1].Reveal(this);
            }
            else Console.WriteLine("This cell has already been cleared");
            Console.WriteLine();

            Draw();
        }

        public void Draw()
        {
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");

            Console.WriteLine();

            for (int row = 0; row < NumRow; row++)
            {
                if (row + 1 < 10) Console.Write(row + 1 + "  ");
                else Console.Write(row + 1 + " ");

                for (int col = 0; col < NumCol; col++)
                {
                    if (game[row, col].Visibility == CellVisibility.Revealed)
                    {
                        if (game[row, col].IsMine)
                        {
                            Console.Write("M "); 
                        }
                        else
                        {
                            Console.Write(game[row, col].MinesAround + " ");
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