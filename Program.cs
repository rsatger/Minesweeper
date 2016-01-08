using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {


            Game game = new Game();


            Console.WriteLine("Starting the game");
            Console.WriteLine();

            game.Draw();

            while (!game.gameOver ) //&& game.cellsRevealed < 90) // while 
            {
                game.Play();
            }

            if (game.gameOver) Console.WriteLine("GameOver");

            //if (game.cellsRevealed == 90) Console.WriteLine("You won !");

            //game.Draw();



            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            



        }
    }
}
