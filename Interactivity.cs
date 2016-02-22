using System;
using System.Runtime.InteropServices;

namespace Minesweeper
{
    public class Interactivity
    {        
        //, IConsoleWrapper console
        public bool ReadInput(string dim, var userInput )
        {
            int dimNumber = 0;

            ConsoleWrapper console = new ConsoleWrapper();

            //testing 
            //SimulateNonIntegerUserInput console = new SimulateNonIntegerUserInput();
            
            Console.Write("Enter " + dim + ": ");

            userInput = console.ReadUserInput();

            while(!CheckTypeIsInteger(userInput, dimNumber)) // must probably be passed by reference
            {
                Console.WriteLine("Please enter an integer");
                return false;
            }
            return dimNumber;
        }

        public bool CheckTypeIsInteger(string userInput, int dimNumber) // passage par ref
        {
            if (!Int32.TryParse(userInput, out dimNumber))
            {
                Console.WriteLine("Please enter an integer");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    
}

