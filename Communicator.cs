using System;
using Minesweeper.Logs;

namespace Minesweeper
{
    public class Communicator : ICommunicator
    {
        private readonly Log _log;

        public Communicator()
        {
            _log = new Log();
        }

        public string Read()
        {
            var input = Console.ReadLine();
            _log.WriteInLog(input, 1);
            return input;
        }

        public void WriteLine(string message)
        {
            _log.WriteInLog(message, 2);
            Console.WriteLine(message);
        }
        
        public void Write(string message)
        {
            _log.WriteInLog(message, 2);
            Console.Write(message);
        }
    }
}