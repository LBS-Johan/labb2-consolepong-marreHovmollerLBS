using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Paddle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set; }

        public Paddle(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }
        public void Move(int yAmount)
        {
            Y += yAmount;
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            for (int i = 0; i < Size; i++)
            {
                Console.Write("┃");
                Console.SetCursorPosition(X, Y + i);
            }
        }
    }
}
