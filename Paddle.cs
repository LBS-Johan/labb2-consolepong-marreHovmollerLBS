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

        /// <summary>
        /// Kollar om brädet får röra sig utifrån nuvarande riktning och storlek på planen
        /// </summary>
        /// <param name="direction">Brädets nuvarande riktning (-1 eller 1)</param>
        /// <returns>true om brädet får röra sig, annars false</returns>
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

        /// <summary>
        /// Ritar ut symbolen "┃" vid alla positioner som brädet består av
        /// </summary>
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

        /// <summary>
        /// Uppdatera arrayen med Vector2-positioner som brädet består av
        /// </summary>
        public void GetPositions()
        {
            // Höj Y-värdet med ett steg och skapa en position baserat på storleken på Size, så att brädet får rätt längd
            for (int i = 0; i < Size; i++)
            {
                Positions[i] = new Vector2(X, Y + i); 
            }
        }
    }
}
