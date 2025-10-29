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
        /// En boll
        /// </summary>
        /// <param name="x">x-position</param>
        /// <param name="y"></param>
        /// <param name="xVelocity"></param>
        /// <param name="yVelocity"></param>
        public Ball(int x, int y, int xVelocity, int yVelocity)
        {
            X = x;
            Y = y;
            XVelocity = xVelocity;
            YVelocity = yVelocity;
        }
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
        /// Ritar ut bollen
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y); //aosdhfashdf
            Console.Write("◯");
        }
        public void CheckCollisions(Paddle p1, Paddle p2)
        {
            if (Y == Game.Height - 1 || Y == 1) //Nuddar bollen övre eller nedre kanten
            {
                YVelocity *= -1;
            }
            foreach (Vector2 position in p1.Positions)
            {
                if (position.Y == Y && position.X == X - 1)
                {
                    XVelocity *= -1;
                    Program.SpeedUp();
                }
            }
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
