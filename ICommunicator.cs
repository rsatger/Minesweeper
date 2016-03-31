namespace Minesweeper
{
    public interface ICommunicator
    {
        string Read(Log log);
        void Write(string message, Log log);
    }
}