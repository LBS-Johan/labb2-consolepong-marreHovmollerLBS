using System.Text;

namespace Labb2_ConsolePong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Tillåt alla Unicode-symboler

            int gameSpeed = 50; //milliseconds per update
            Game game = new Game();
            game.StartGame();

            while (true)
            {
                if (game.Run() == false)
                {
                    Console.WriteLine("Game over");
                    break;
                }

                Thread.Sleep(gameSpeed);
            }
        }
    }
}
