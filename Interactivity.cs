using System;

namespace Minesweeper
{
    public class Interactivity
    {
        public int ReadInput(string dim)
        {
            int dimNumber;
            Console.Write("Enter " + dim + ": ");

            if (!Int32.TryParse(Console.ReadLine(), out dimNumber))
            {
                Console.Write("Please enter an integer");
                Console.WriteLine();
                return ReadInput(dim);
            }
            if (dimNumber < 0 || dimNumber > 10)
            {
                Console.Write("Entry out of range, enter a value corresonding to a " + dim + " number");
                Console.WriteLine();
                return ReadInput(dim);
            }
            return dimNumber;
        }
    }
}