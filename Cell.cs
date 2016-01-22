using System;

namespace Minesweeper
{
    public class Cell
    {
        private readonly int _row;
        private readonly int _col;
        public bool IsMine { get; private set; }

        public int MinesAround;
        public CellVisibility Visibility { get; set; }

        public Cell(int row, int col, bool isMine)
        {
            MinesAround = 0;
            _row = row;
            _col = col;
            Visibility = CellVisibility.Hidden;
            IsMine = isMine;
        }

        public void Reveal(Board board)
        {
            if (!IsMine)
            {
                BrowseAllCells(board, CountMinesAround);

                if (MinesAround == 0)
                {
                    BrowseAllCells(board, Reveal);
                }
            }
            Visibility = CellVisibility.Revealed;
        }

        public void BrowseAllCells(Board board, Action<Cell, Board> cellAction)
        {
            for (int rowIndex = Math.Max(_row - 1, 0); rowIndex <= Math.Min(_row + 1, board.NumRow - 1); rowIndex++)
            {
                for (int columnIndex = Math.Max(_col - 1, 0); columnIndex <= Math.Min(_col + 1, board.NumCol - 1); columnIndex++)
                {
                    cellAction(board.Cells[rowIndex, columnIndex], board);
                }
            }
        }

        private void CountMinesAround(Cell cell, Board board)
        {
            if (cell.IsMine)
            {
                MinesAround++;
            }
        }

        private void Reveal(Cell cell, Board board)
        {
            cell.Reveal(board);
        }

        #region delegate

        public void Reveal2(Board board)
        {
            CellAction2 += CountMinesAround;
            CellAction2 += Reveal;

            if (!IsMine)
            {
                BrowseAllCells2(board);
            }
            Visibility = CellVisibility.Revealed;
        }

        public delegate void EachCellAction(Cell cell, Board board); // Step 1

        public EachCellAction CellAction2 = null;

        public void BrowseAllCells2(Board board)
        {
            for (int rowIndex = Math.Max(_row - 1, 0); rowIndex <= Math.Min(_row + 1, board.NumRow - 1); rowIndex++)
            {
                for (int columnIndex = Math.Max(_col - 1, 0); columnIndex <= Math.Min(_col + 1, board.NumCol - 1); columnIndex++)
                {
                    CellAction2(board.Cells[rowIndex, columnIndex], board);
                }
            }
        }

        #endregion delegate
    }
}