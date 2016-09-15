using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleApplication1
{
    public class Game
    {
        public static Coordinate screenCenter;
        public static Coordinate drawPos;

        public static Player player;
        public static Blinky blinky;
        public static Inky inky;
        public static Map map1;
        public static int score;

        static string message;
        public static bool exit;

        public static Stopwatch gameSW = new Stopwatch();
        public static Stopwatch avoidSW = new Stopwatch();

        static void Main(string[] args)
        {

            gameSW.Start();

            Console.SetWindowSize(70, 50);
            screenCenter = new Coordinate((Console.WindowWidth / 2),(Console.WindowHeight / 2));
            drawPos = new Coordinate(screenCenter.X, screenCenter.Y);

            Console.Title = "Matt's Pacman";
            message = "ARE YOU READY TO RUMBLE!?!";
            Game.WriteMessage(message, drawPos.X, drawPos.Y, true);
            message = "Press Enter To Begin";
            Game.WriteMessage(message, drawPos.X, drawPos.Y + 2, true);

            message = "Use WASD to move...";
            Game.WriteMessage(message, drawPos.X, drawPos.Y + 10, true);

            Console.ReadLine();
            
            exit = false;
            map1 = new Map();
            player = new Player(new Coordinate(1 + Map.mapOffset.X, 1 + Map.mapOffset.Y));
            blinky = new Blinky(new Coordinate(Map.mapOffset.X + Map.mapCoords.GetLength(0) / 2, Map.mapOffset.Y + Map.mapCoords.GetLength(1) / 2));
            inky = new Inky(new Coordinate(Map.mapOffset.X + Map.mapCoords.GetLength(0) / 2 - 3, Map.mapOffset.Y + Map.mapCoords.GetLength(1) / 2));
            while (!exit)
            {
                if (gameSW.ElapsedMilliseconds > 150)
                {
                    Update();
                    gameSW.Restart();
                }
            }

            Console.ReadLine();
            Console.Clear();
            Console.ReadLine();
        }

        private static void Update()
        {
            player.Update();
            blinky.Update();
            inky.Update();
            // Draw all elements
            Draw();
        }

        private static void Draw()
        {

            Console.Clear();
            map1.DrawMap();
            player.Draw();
            blinky.Draw();
            inky.Draw();
            
            Console.ForegroundColor = ConsoleColor.White;
            WriteMessage("Score: " + score, 2, 5, false);
        }

        public static void WriteMessage(string inMessage, int x, int y, bool centered)
        {
            if(centered)
                Console.SetCursorPosition(x - inMessage.Length / 2, y);
            else
                Console.SetCursorPosition(x, y);
            Console.WriteLine(inMessage);
        }
    }
}
