﻿using System;

namespace Minesweeper
{
    public class Interactivity
    {
        private int _intUserInput = 0;
        internal int _rowInput = 0;
        internal int _colInput = 0;

        public DimensionType Dimension { get; set; }

        public void GetUserCellInput()
        {
            bool checkRowInput = false;
            bool checkColInput = false;

            Dimension = DimensionType.Row;
            while (!checkRowInput)
            {
                checkRowInput = GetUserInput(Dimension);
                _rowInput = _intUserInput;
            }

            Dimension = DimensionType.Column;
            while (!checkColInput)
            {
                checkColInput = GetUserInput(Dimension);
                _colInput = _intUserInput;
            }
        }

        public bool GetUserInput(DimensionType dimension)
        {
            string input;
            ConsoleWrapper console = new ConsoleWrapper();

            Console.Write("Enter " + dimension + ": ");

            input = console.ReadUserInput();

            bool result = CheckTypeIsInteger(input);

            if (result)
            {
                return CheckBoundaries(_intUserInput, dimension);
            }
            else return false;
        }

        public bool CheckTypeIsInteger(string userInput)
        {
            if (!Int32.TryParse(userInput, out _intUserInput))
            {
                Console.WriteLine("Please enter an integer");
                return false;
            }
            else return true;
        }

        public bool CheckBoundaries(int input, DimensionType dimension)
        {
            if (input <= 0 || input > 10)
            {
                Console.WriteLine("Entry out of range, enter a value corresonding to a " + dimension + " number");
                return false;
            }
            else return true;
        }
    }
}