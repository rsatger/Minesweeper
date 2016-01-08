using System;

namespace Minesweeper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game();

            Console.WriteLine("Starting the game");
            Console.WriteLine();

            game.Draw();

            while (!game.GameOver)
            {
                game.Play();
            }

            Console.WriteLine(game.GameOver ? "GameOver" : "You won !");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}