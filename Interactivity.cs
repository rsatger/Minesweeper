using System;

namespace Minesweeper
{
    public class Interactivity
    {
        private readonly ICommunicator _communicator;
        private readonly Log _log;


        public  Interactivity(ICommunicator com, Log log)
        {
            _communicator = com;
            _log = log;
        }
        
        public int GetValidIndex(DimensionType dimension)
        {
            var isValidBoundaries = false;
            var isValidInteger = false;
            var index = int.MinValue;
           
            while(!isValidBoundaries && !isValidInteger)
            {
                _communicator.Write(string.Format(MessageResources.EnterInput, dimension), _log);
                var input = _communicator.Read(_log);

                //_log.WriteInLog(string.Format("{1}Enter {0}: ", dimension, Environment.NewLine), 2);

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
                _communicator.Write(MessageResources.CheckIntegerError, _log);
                _log.WriteInLog(MessageResources.CheckIntegerError, 2);

                index = -1;
                return false;
            }
            else return true;
        }

        public bool CheckBoundaries(int input, DimensionType dimension)
        {
            if (input <= 0 || input > 10)
            {
                _communicator.Write(string.Format(MessageResources.CheckBoundariesError, dimension), _log);
                _log.WriteInLog(MessageResources.CheckBoundariesError, 2);
                return false;
            }
            else return true;
        }
    }
}