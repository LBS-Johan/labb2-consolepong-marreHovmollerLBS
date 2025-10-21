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

            XVelocity = Game.RandomNumber(0, 1) == 2 ? -1 : 1;
            YVelocity = Game.RandomNumber(0, 1) == 2 ? -1 : 1;
        }
        public void Move()
        {
            X += XVelocity;
            Y += YVelocity;
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("◯");
            Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            foreach (Vector2 position in p2.Positions)
            {
                if (position.Y == Y && position.X == X + 1)
                {
                    XVelocity *= -1;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
            if (X == Game.Width - 1 || X == 1)
            {
                X = Game.Width / 2;
                Y = Game.Height / 2;
            }
        }
    }
}
