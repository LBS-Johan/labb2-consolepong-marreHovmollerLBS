using System.Text;

namespace Labb2_ConsolePong
{
    internal class Program
    {
        static float baseSpeed;
        static float speedModifier;
        static float gameSpeed; //milliseconds per update
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Tillåt alla Unicode-symboler

            baseSpeed = 60;
            gameSpeed = baseSpeed;
            speedModifier = 0.9f;
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

                Thread.Sleep((int) Math.Round(gameSpeed));
            }
        }
        public static void SpeedUp()
        {
            gameSpeed *= speedModifier; 
        }
        public static void ResetSpeed()
        {
            gameSpeed = baseSpeed;
        }
    }
}
