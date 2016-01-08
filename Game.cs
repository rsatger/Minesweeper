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


    public class Game
    {
        public int _numCol;
 
        public int _numRow;

        public Cell[,] game;

        public int CellsRevealed;

        public bool gameOver; // to use

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

            if (!game[row - 1, col - 1].IsRevealed)
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