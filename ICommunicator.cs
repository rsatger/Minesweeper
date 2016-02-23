namespace Minesweeper
{
    public interface ICommunicator
    {
        string Read();
        void Write(string message);
    }
}