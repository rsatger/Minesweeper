namespace Minesweeper
{
    public class Cell
    {
        public readonly int _row;
        public readonly int _col;
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
    }
}