using System;

namespace Minesweeper
{
    public interface IConsoleWrapper
    {
        string ReadUserInput();
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadUserInput()
        {
            return Console.ReadLine();
        }
    }

    public class SimulateNonIntegerUserInput : IConsoleWrapper
    {
        public string ReadUserInput()
        {
            return "a#1";
        }
    }

    public class SimulateNullUserInput : IConsoleWrapper
    {
        public string ReadUserInput()
        {
            return null;
        }
    }

    public class SimulateOutOfRangeUserInput : IConsoleWrapper
    {
        public string ReadUserInput()
        {
            return "21";
        }
    }
}