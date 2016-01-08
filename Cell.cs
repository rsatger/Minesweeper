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

        public void Reveal(Game board)
        {
            if (IsMine)
            {
                Visibility = CellVisibility.Revealed;
            }
            else
            {
                for (int rowIndex = Math.Max(_row - 1, 0); rowIndex <= Math.Min(_row + 1, board.NumRow - 1); rowIndex++)
                {
                    for (int columnIndex = Math.Max(_col - 1, 0); columnIndex <= Math.Min(_col + 1, board.NumCol - 1); columnIndex++)
                    {
                        if (board.game[rowIndex, columnIndex].IsMine)
                        {
                            MinesAround++;
                        }
                    }
                }

                if (MinesAround == 0)
                {
                    for (int rowIndex = Math.Max(_row - 1, 0); rowIndex <= Math.Min(_row + 1, board.NumRow - 1); rowIndex++)
                    {
                        for (int columnIndex = Math.Max(_col - 1, 0); columnIndex <= Math.Min(_col + 1, board.NumCol - 1); columnIndex++)
                        {
                            board.game[rowIndex, columnIndex].Reveal(board);
                        }
                    }
                }
                Visibility = CellVisibility.Revealed;
            }
        }
    }
}