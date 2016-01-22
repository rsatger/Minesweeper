using System;
using System.Runtime.InteropServices;

namespace Minesweeper
{
    public class Board
    {
        public readonly int NumCol;
        public readonly int NumRow;

        public readonly Cell[,] Cells;
        public bool GameOver; 
        public int CellsRevealed;
        public readonly int Dimension;

        public Board()
        {
            NumCol = 10;
            NumRow = 10;
            CellsRevealed = 0;
            Dimension = NumCol*NumRow; 

            Cells = InitializeGame(NumRow, NumCol);
        }

        #region Initialize
        private Cell[,] InitializeGame(int maxRow, int maxCol)
        {
            var mines = InitializeMines(maxRow, maxCol);
            
            var game = new Cell[maxRow, maxCol];
            for (int row = 0; row < maxRow; row++)
                for (int col = 0; col < maxCol; col++)
                {
                    game[row, col] = new Cell(row, col, mines[row, col]);
                }

            InitializeMinesAround(game);
            return game;
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

        private void InitializeMinesAround(Cell[,] game)
        {
            for (int rowIndex = 0; rowIndex <= NumRow - 1; rowIndex++)
            {
                for (int columnIndex = 0;columnIndex <= NumCol - 1; columnIndex++)
                {
                    SetMinesAround(rowIndex, columnIndex, game);
                }
            }
        }

        private void SetMinesAround(int _row, int _col, Cell[,] game)
        {
            for (int rowIndex = Math.Max(_row - 1, 0); rowIndex <= Math.Min(_row + 1, NumRow - 1); rowIndex++)
            {
                for (int columnIndex = Math.Max(_col - 1, 0); columnIndex <= Math.Min(_col + 1, NumCol - 1); columnIndex++)
                {
                    if (game[rowIndex, columnIndex].IsMine)
                    {
                        game[_row, _col].MinesAround++;
                    }
                }
            }
        }
        #endregion

        public bool TreatUserInput(int row, int col)
        {
            if (Cells[row - 1, col - 1].Visibility == CellVisibility.Revealed) 
                return false;

            Cells[row - 1, col - 1].Visibility = CellVisibility.Revealed;
            CellsRevealed ++;

            if (Cells[row - 1, col - 1].IsMine)
            {
                GameOver = true;
                return true;
            }
            
            if (Cells[row - 1, col - 1].MinesAround == 0)
                PropagateReveal(Cells[row - 1, col - 1]);

            return true;
        }

        private void PropagateReveal(Cell cell) 
        {
            for (int rowIndex = Math.Max(cell._row - 1, 0); rowIndex <= Math.Min(cell._row + 1, NumRow - 1); rowIndex++)
            {
                for (int columnIndex = Math.Max(cell._col - 1, 0); columnIndex <= Math.Min(cell._col + 1, NumCol - 1); columnIndex++)
                {
                    
                    if (Cells[rowIndex, columnIndex].Visibility != CellVisibility.Revealed && Cells[rowIndex, columnIndex].MinesAround == 0)
                    {
                        Cells[rowIndex, columnIndex].Visibility = CellVisibility.Revealed;
                        PropagateReveal(Cells[rowIndex, columnIndex]);
                        CellsRevealed ++;
                    }
                }
            }
        }
    }
}