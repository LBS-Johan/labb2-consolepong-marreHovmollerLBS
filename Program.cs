using System.Text;

namespace Labb2_ConsolePong
{
    internal class Program
    {
        // Hastighet gäller millisekunder per uppdatering
        static float baseSpeed;     //Ursprunglig hastighet
        static float speedModifier; //Förändringsfaktor för spelets hastighet
        static float gameSpeed;     //Faktisk hastighet, avrundas till int
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Tillåt fler Unicode-symboler

            baseSpeed = 60;
            speedModifier = 0.9f;
            ResetSpeed();
           
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

                Thread.Sleep((int) Math.Round(gameSpeed));  //Avrundar float gameSpeed till närmaste int och väntar i så många millisekunder
            }
        }
        /// <summary>
        /// Sänker antalet millisekunder/ uppdatering genom att multiplicera tidigare antal med en förändringsfaktor mindre än 1
        /// </summary>
        public static void SpeedUp()
        {
            gameSpeed *= speedModifier; 
        }

        /// <summary>
        /// Återställer antalet millisekunder/ uppdatering genom att sätta det till det ursprungliga värdet
        /// </summary>
        public static void ResetSpeed()
        {
            gameSpeed = baseSpeed;
        }
    }
}
