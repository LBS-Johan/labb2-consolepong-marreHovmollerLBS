using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ConsolePong
{
    internal class Game
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        int score1;
        int score2;
        Paddle player1;
        Paddle player2;
        Ball ball;
        
        public void StartGame()
        {
            // Setup konsol-fönstret
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;

            score1 = 0;
            score2 = 0;
            player1 = new Paddle(1, 10, 5);
            player2 = new Paddle(Width - 1, 10, 5);
            ball = new Ball(Width / 2, Height / 2, 1, 1);

            Console.CursorVisible = false;
        }

        public bool Run()
        {
            //Töm hela skärmen i början av varje uppdatering.
            Console.Clear();
            Update();
            CheckInput();
            //Return true om spelet ska fortsätta
            return !CheckWin();
        }
        void Update()
        {
            // Spelar-relaterat
            player1.GetPositions();
            player2.GetPositions();
            // Ball-relaterat
            ball.CheckCollisions(player1, player2);
            ball.Move();
            // Spel-relaterat
            CheckScore();
            Draw();
        }
        void CheckInput()
        {
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
        }
        void Reset()
        {
            int countdownLength = 3;
            int duration = 500;

            for (int i = countdownLength; i > 0; i--)
            {
                Console.SetCursorPosition(Width / 2, Height / 2);
                Console.Write(i);
                Draw();

                Thread.Sleep(duration);

                Console.Clear();
            }
            ball.Reset();
            Program.ResetSpeed();
        }
        void CheckScore()
        {
            if (ball.X == 1)
            {
                score2++;
                Reset();
            }
            if(ball.X == Width - 1)
            {
                score1++;
                Reset();
            }
        }
        void Draw()
        {
            Console.SetCursorPosition(2, 1);
            Console.Write(score1);
            Console.SetCursorPosition(Width - 2, 1);
            Console.Write(score2);

            player1.Draw();
            player2.Draw();

            ball.Draw();
        }
        bool CheckWin()
        {
            return false;
        }
        public static int RandomNumber(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}

