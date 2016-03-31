using System;

namespace Minesweeper
{
    public class Communicator : ICommunicator
    {
        public Log log;

        public string Read(Log log)
        {
            var input = Console.ReadLine();
            log.WriteInLog(input, 1);
            return input;
        }

        public void Write(string message, Log log)
        {
            log.WriteInLog(message, 2);
            Console.WriteLine(message);
        }
    }
}