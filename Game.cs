using System;
using System.Data;

namespace Minesweeper
{
    public enum CellStates
    {
        HiddenSafe,
        HiddenMine,
        RevealedSafe,
        RevealedMine
    }


    public class Cell
    {
        public int _minesAround; 
        public int _row, _col;

        public CellStates CellState { get; set; } // property

        public bool IsRevealed // property
        {
            get { return CellState == CellStates.RevealedMine || CellState == CellStates.RevealedSafe; }
            set { } // ?
        }

        public bool ContainsMine
        {
            get { return CellState == CellStates.HiddenMine || CellState == CellStates.RevealedMine; }
            set { }
        }
        
        public Cell(int row, int col)
        {
            _minesAround = 0;
            _row = row;
            _col = col;
            CellState = CellStates.HiddenSafe;
        }

        //public int Reveal()
        //{
        //    if (ContainsMine)
        //    {
        //        CellState = CellStates.RevealedMine;

        //        //Console.Write("GameOver"); // move this somewhere else ? Check when calling Draw ? Create event ?
        //    }
        //    else
        //    {
        //        for (int i = Math.Max(_row - 1, 0); i <= Math.Min(_row + 1, 10 -1); i++) //Game._numRow
        //        {
        //            for (int j = Math.Max(_col - 1, 0); j <= Math.Min(_col + 1, 10 - 1); j++)
        //            {
        //                if (this.ContainsMine)
        //                {
        //                    _minesAround++; // count number of neighbooring mines
        //                }
        //            }
        //        }

                

        //        //game[row, col] = count; // update board array with number of neighbooring mines
        //        //CellsRevealed++; // update number of cell 

        //        if (_minesAround == 0) // if cell has no neighbooring mines, reveal neighoor cells, and so on 
        //        {
        //            for (int i = Math.Max(_row - 1, 0); i <= Math.Min(_row + 1, 10 - 1); i++)
        //            {
        //                for (int j = Math.Max(_col - 1, 0); j <= Math.Min(_col + 1, 10 - 1); j++)
        //                {
        //                    Reveal(i, j);
        //                }
        //            }
        //        }
        //    }
        //}
    }


    public class Game
    {
        public int _numCol;
        public int _numRow;

        public Cell[,] game;

        // counting cells revealed since game started
        public int CellsRevealed;

        // store true if mine revealed
        public bool gameOver;

        //public int numCol() { get; set; }

        //public int numRow { get; set; }


        public Game()
        {
            _numCol = 10;

            _numRow = 10;

            game = new Cell[_numRow, _numCol];
            // clean Cell table
            for (int i = 0; i < _numRow; i++)
                for (int j = 0; j < _numCol; j++)
                {
                    game[i, j] = new Cell(i, j);
                }

            //cellsRevealed = 0;

            gameOver = false;

            // to do: use randomization 
            // 10 mines locations
            game[3, 1].CellState = CellStates.HiddenMine;
            game[1, 2].CellState = CellStates.HiddenMine;
            game[6, 2].CellState = CellStates.HiddenMine;
            game[6, 8].CellState = CellStates.HiddenMine;
            game[9, 9].CellState = CellStates.HiddenMine;
            game[4, 6].CellState = CellStates.HiddenMine;
            game[9, 2].CellState = CellStates.HiddenMine;
            game[6, 1].CellState = CellStates.HiddenMine;
            game[2, 7].CellState = CellStates.HiddenMine;
            game[9, 7].CellState = CellStates.HiddenMine;
        }


        public void Reveal(Cell cell)
        {
            if (cell.ContainsMine)
            {
                cell.CellState = CellStates.RevealedMine;

                //Console.Write("GameOver"); // move this somewhere else ? Check when calling Draw ? Create event ?
            }
            else
            {
                for (int i = Math.Max(cell._row - 1, 0); i <= Math.Min(cell._row + 1, 10 - 1); i++) //Game._numRow
                {
                    for (int j = Math.Max(cell._col - 1, 0); j <= Math.Min(cell._col + 1, 10 - 1); j++)
                    {
                        if (game[i, j].ContainsMine)
                        {
                            cell._minesAround++; // count number of neighbooring mines
                           
                        }
                    }
                }



                //game[row, col] = count; // update board array with number of neighbooring mines
                //CellsRevealed++; // update number of cell 

                if (cell._minesAround == 0) // if cell has no neighbooring mines, reveal neighoor cells, and so on 
                {
                    for (int i = Math.Max(cell._row - 1, 0); i <= Math.Min(cell._row + 1, 10 - 1); i++)
                    {
                        for (int j = Math.Max(cell._col - 1, 0); j <= Math.Min(cell._col + 1, 10 - 1); j++)
                        {
                            Reveal(game[i, j]);
                        }
                    }
                }

                cell.CellState = CellStates.RevealedSafe;
            }
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

            

            if (!game[row - 1, col - 1].IsRevealed) // if cell hidden
            {
                // reveal the cell selected by user
                Reveal(game[row- 1, col - 1]);
         
            }
            else Console.WriteLine("This cell has already been cleared"); // get this out of method
            Console.WriteLine();

            // display updated game board
            Draw();
        }


        


        //// reveal the cell selected by user
        //public void Reveal(int row, int col)
        //{
        //    if (mine[row, col]) // if cell contains a mine
        //    {
        //        game[row, col] = -2;

        //        Console.Write("GameOver"); // move this somewhere else ? Check when calling Draw ? Create event ?
        //        gameOver = true;
        //    }
        //    else // if cell does not contain a mine
        //    {
        //        int count = 0;

        //        for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, _numRow - 1); i++)
        //        {
        //            for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, _numCol - 1); j++)
        //            {
        //                if (mine[i, j])
        //                {
        //                    count++; // count number of neighbooring mines
        //                }
        //            }
        //        }

        //        game[row, col] = count; // update board array with number of neighbooring mines
        //        cellsRevealed++; // update number of cell 

        //        if (count == 0) // if cell has no neighbooring mines, reveal neighoor cells, and so on 
        //        {
        //            for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, _numRow - 1); i++)
        //            {
        //                for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, _numCol - 1); j++)
        //                {
        //                    Reveal(i, j);
        //                }
        //            }
        //        }
        //    }
        //}


        public void Draw()
        {
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");

            Console.WriteLine();

            for (int i = 0; i < _numRow; i++)
            {
                if (i + 1 < 10) Console.Write(i + 1 + "  ");
                else Console.Write(i + 1 + " ");

                for (int j = 0; j < _numCol; j++)
                {
                    switch (game[i, j].CellState)
                    {
                        case CellStates.RevealedSafe:
                            Console.Write(game[i, j]._minesAround + " ");
                            break;
                        
                        case CellStates.RevealedMine:
                            Console.Write("M ");
                            break;

                        default:
                            Console.Write("- ");
                            break;
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