using System.Text;

namespace Labb2_ConsolePong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Tillåt alla Unicode-symboler

            int gameSpeed = 30; //milliseconds per update
            Game game = new Game();
            game.StartGame();

            while (true)
            {
                if (!game.Run())
                {
                    Console.Clear();
                    Console.SetCursorPosition(Game.Width / 2, Game.Height / 2);
                    Console.WriteLine("Game over");
                    break;
                }

                Thread.Sleep(gameSpeed);
            }
        }
    }
}
