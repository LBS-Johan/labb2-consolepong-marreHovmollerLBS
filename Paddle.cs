using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Paddle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set; }
        public Vector2[] Positions { get; private set; }
        public Paddle(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
            Positions = new Vector2[size];
        }
        public void Move(int yAmount)
        {
            if(MoveAllowed(yAmount))
            {
                Y += yAmount;
            }
        }
        private bool MoveAllowed(int direction)
        {
            foreach (Vector2 position in Positions)
            {
                if ((direction < 0 && position.Y == 1) || 
                    (direction > 0 && position.Y == Game.Height - 1))
                {
                    return false;
                }
            }
            return true;
        }
        public void Draw()
        {
            foreach (Vector2 position in Positions)
            {
                int intX = (int)position.X;
                int intY = (int)position.Y;
                Console.SetCursorPosition(intX, intY);
                Console.Write("┃");
            }
        }
        public void GetPositions()
        {
            for (int i = 0; i < Size; i++)
            {
                Positions[i] = new Vector2(X, Y + i);
            }
        }
    }
}
