using System.Collections.Generic;

namespace Minesweeper
{
    public class SimulateCommunicator : ICommunicator
    {
        public readonly List<string> AllWrite = new List<string>() { };
        public int CountRead;
        private string value;

        public SimulateCommunicator(string arg)
        {
            value = arg;
        }

        public string Read()
        {
            CountRead++;
            return value;
        }

        public void Write(string message)
        {
            AllWrite.Add(message);
        }
    }
}