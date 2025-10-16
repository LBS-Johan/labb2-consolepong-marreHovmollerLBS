using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Game
    {
        int width;
        int height;
        Paddle player1;
        Paddle player2;

        public void StartGame()
        {
            // Setup konsol-fönstret
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            Console.CursorVisible = false;

            player1 = new Paddle(1, 10, 7);
            player2 = new Paddle(width - 1, 10, 7);
        }

        public bool Run()
        {
            //Töm hela skärmen i början av varje uppdatering.
            Console.Clear();

            if (Input.IsPressed(ConsoleKey.UpArrow))
            {
                player2.Move(-1); //Flytta spelare 2 uppåt
            }
            if (Input.IsPressed(ConsoleKey.DownArrow))
            {
                player2.Move(1); //Flytta spelare 2 nedåt
            }

            if (Input.IsPressed(ConsoleKey.W))
            {
                player1.Move(-1); //Flytta spelare 1 uppåt
            }
            if (Input.IsPressed(ConsoleKey.S))
            {
                player1.Move(1); //Flytta spelare 1 nedåt
            }

            Update();

            //Return true om spelet ska fortsätta
            return true;

        }
        void Update()
        {
            player1.Draw();
            player2.Draw();
        }
    }
}
