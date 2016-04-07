using Minesweeper.Logs;

namespace Minesweeper
{
    public interface ICommunicator
    {
        string Read();
        void WriteLine(string message);
        void Write(string message);
    }
}