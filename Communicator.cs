using System;

namespace Minesweeper
{
    public class Communicator : ICommunicator
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}