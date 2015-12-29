using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Game
    {
        private int numCol, numRow;

        // store true if cell contains mine
        private bool[,] mine;

        // stores cells status:
        //-2 if mine revealed 
        //-1 if cell hidden
        //number of neighbooring mines otherwise
        private int[,] game;

        // counting cells revealed since game started
        public int cellsRevealed;

        // store true if mine revealed
        public bool gameOver;

        //public int numCol() { get; set; }

        //public int numRow { get; set; }


        public Game()
        {
            numCol = 10;

            numRow = 10;

            mine = new bool[numRow, numCol];
            // clean mine table
            for (int i = 0; i < numRow; i++)
                for (int j = 0; j < numCol; j++)
                {
                    mine[i, j] = false;
                }

            game = new int[numRow, numCol];
            // clean game table
            for (int i = 0; i < numRow; i++)
                for (int j = 0; j < numCol; j++)
                {
                    game[i, j] = -1;
                }

            cellsRevealed = 0;

            gameOver = false;

            // to do: use randomization 
            // 10 mines locations
            mine[3, 1] = true;
            mine[1, 2] = true;
            mine[6, 2] = true;
            mine[6, 8] = true;
            mine[9, 9] = true;
            mine[4, 6] = true;
            mine[9, 2] = true;
            mine[6, 1] = true;
            mine[2, 7] = true;
            mine[9, 7] = true;
        }

        // core method of the game
        public void Play()
        {
            int row;
            int col;

            // asking user to select cell to reveal
            Console.Write("Enter row: ");
            if (Int32.TryParse(Console.ReadLine(), out row))
            {
                // exception handling ?
            }

            Console.Write("Enter column: ");
            if (Int32.TryParse(Console.ReadLine(), out col))
            {
                // exception handling ?
            }

            Console.WriteLine();

            if (game[row-1, col-1] == -1) // if cell hidden
            {
                // reveal the cell selected by user
                Reveal(row - 1, col - 1);
            }
            else Console.WriteLine("This cell has already been cleared"); // get this out of method
            Console.WriteLine();

            // display updated game board
            Draw();
        }


        // reveal the cell selected by user
        public void Reveal(int row, int col)
        {
            if (mine[row, col]) // if cell contains a mine
            {
                game[row, col] = -2;

                Console.Write("GameOver"); // move this somewhere else ? Check when calling Draw ? Create event ?
                gameOver = true;
            }
            else // if cell does not contain a mine
            {
                int count = 0;

                for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, numRow - 1); i++) 
                {
                    for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, numCol - 1); j++)
                    {
                        if (mine[i, j])
                        {
                            count++; // count number of neighbooring mines
                        }
                    }
                }

                game[row, col] = count; // update board array with number of neighbooring mines
                cellsRevealed++; // update number of cell 

                if (count == 0) // if cell has no neighbooring mines, reveal neighoor cells, and so on 
                {
                    for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, numRow - 1); i++)
                    {
                        for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, numCol - 1); j++)
                        {
                            Reveal(i, j);
                        }
                    }
                }
            }
            

        }




        public void Draw()
        {
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine();

            for (int i = 0; i < numRow; i++)
            {
                if (i + 1 < 10) Console.Write(i + 1 + "  ");
                else Console.Write(i + 1 + " ");

                for (int j = 0; j < numCol; j++)
                {

                    switch (game[i, j])
                    {
                        case -1:
                            Console.Write("- ");
                            break;
                        case -2:
                            Console.Write("M ");
                            break;

                        default:
                            Console.Write(game[i, j] + " ");
                            break;
                    }


                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(cellsRevealed + " cells cleared");
            Console.WriteLine();

        }




    }
}
