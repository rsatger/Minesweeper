using System;
using Minesweeper.Logs;

namespace Minesweeper
{
    public class Interactivity
    {
        private readonly ICommunicator _communicator;
        

        public  Interactivity(ICommunicator com)
        {
            _communicator = com;
        }
        
        public int GetValidIndex(DimensionType dimension)
        {
            var isValidBoundaries = false;
            var isValidInteger = false;
            var index = int.MinValue;
           
            while(!isValidBoundaries || !isValidInteger)
            {
                _communicator.Write(string.Format(MessageResources.EnterInput, dimension));
                var input = _communicator.Read();

                isValidInteger = CheckTypeIsInteger(input, out index);
                if (isValidInteger)
                {
                    isValidBoundaries = CheckBoundaries(index, dimension);
                }
            }

            return index;
        }

        public bool CheckTypeIsInteger(string userInput, out int index)
        {
            if (userInput == null || !int.TryParse(userInput, out index))
            {
                _communicator.WriteLine(MessageResources.CheckIntegerError);
                

                index = -1;
                return false;
            }
            else return true;
        }

        public bool CheckBoundaries(int input, DimensionType dimension)
        {
            if (input <= 0 || input > 10)
            {
                _communicator.WriteLine(string.Format(MessageResources.CheckBoundariesError, dimension));
                
                return false;
            }
            else return true;
        }
    }
}