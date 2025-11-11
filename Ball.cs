using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Ball
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int XVelocity { get; private set; }
        public int YVelocity { get; private set; }

        /// <summary>
        /// Boll
        /// </summary>
        /// <param name="x">position i X-led</param>
        /// <param name="y">position i Y-led</param>
        /// <param name="xVelocity">hastighet i X-led</param>
        /// <param name="yVelocity">hastighet i Y-led</param>
        public Ball(int x, int y, int xVelocity, int yVelocity)
        {
            X = x;
            Y = y;
            XVelocity = xVelocity;
            YVelocity = yVelocity;
        }
        /// <summary>
        /// Flytta bollen till mitten och slumpa riktning
        /// </summary>
        public void Reset()
        {
            X = Game.Width / 2;
            Y = Game.Height / 2;

            XVelocity = Game.RandomNumber(0, 2) == 1 ? -1 : 1;
            YVelocity = Game.RandomNumber(0, 2) == 1 ? -1 : 1;
        }
        public void Move()
        {
            X += XVelocity;
            Y += YVelocity;
        }

        /// <summary>
        /// Ritar ut bollen vid rätt X- och Y-position med symbolen "◯"
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("◯");
        }

        /// <summary>
        /// Kontrollerar om bollen nuddar någon av spelarna eller tak/golv.
        /// </summary>
        /// <param name="p1">Spelare 1:s bräde</param>
        /// <param name="p2">Spelare 2:s bräde</param>
        public void CheckCollisions(Paddle p1, Paddle p2)
        {
            if (Y == Game.Height - 1 || Y == 1) //Nuddar bollen övre eller nedre kanten
            {
                YVelocity *= -1;
            }
            // Gå igenom alla positioner för spelare 1:s bräde, och vänd bollens X-riktning  om bollen är bredvid
            foreach (Vector2 position in p1.Positions)
            {
                if (position.Y == Y && position.X == X - 1)
                {
                    XVelocity *= -1;
                    Program.SpeedUp();
                }
            }
            // Gå igenom alla positioner för spelare 2:s bräde, och vänd bollens X-riktning om bollen är bredvid
            foreach (Vector2 position in p2.Positions)
            {
                if (position.Y == Y && position.X == X + 1)
                {
                    XVelocity *= -1;
                    Program.SpeedUp();
                }
            }
        }
    }
}