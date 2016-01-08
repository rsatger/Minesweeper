using System;

namespace Minesweeper
{
    public class Cell
    {
        private int _row, _col;
        
        public int _minesAround;

        public CellStates CellState { get; set; } 

        public bool IsRevealed 
        {
            get { return CellState == CellStates.RevealedMine || CellState == CellStates.RevealedSafe; }
            set { } 
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

        public void Reveal(Game board)
        {
            if (ContainsMine)
            {
                CellState = CellStates.RevealedMine;
            }
            else
            {
                for (int i = Math.Max(_row - 1, 0); i <= Math.Min(_row + 1, 10 - 1); i++)
                {
                    for (int j = Math.Max(_col - 1, 0); j <= Math.Min(_col + 1, 10 - 1); j++)
                    {
                        if (board.game[i, j].ContainsMine)
                        {
                            _minesAround++; 
                        }
                    }
                }

                if (_minesAround == 0 )

                {
                    for (int i = Math.Max(_row - 1, 0); i <= Math.Min(_row + 1, 10 - 1); i++)
                    {
                        for (int j = Math.Max(_col - 1, 0); j <= Math.Min(_col + 1, 10 - 1); j++)
                        {
                            board.game[i, j].Reveal(board);
                        }
                    }
                }
                CellState = CellStates.RevealedSafe;
            }
        }
    }
}