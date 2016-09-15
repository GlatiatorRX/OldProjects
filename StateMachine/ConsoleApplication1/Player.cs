using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Player
    {
        private Coordinate position;
        private int lives;
        public bool hasMoved;

        public Player()
        {
            position = new Coordinate(0, 0);
            lives = 3;
            hasMoved = false;
        }

        public Player(Coordinate inPosition)
        {
            position = inPosition;
            lives = 3;
            hasMoved = false;
        }

        public void Update()
        {
            hasMoved = false;
             if (Console.KeyAvailable)
             {
                 ConsoleKeyInfo keyboardInput = Console.ReadKey(false); // read key without displaying it
                 //controls
                 if (keyboardInput.KeyChar.Equals('w'))
                 {
                     Coordinate newPos = new Coordinate(position.X, position.Y - 1);
                     SetPosition(CanMove(newPos));
                 }
                 else if (keyboardInput.KeyChar.Equals('a'))
                 {
                     Coordinate newPos = new Coordinate(position.X - 1, position.Y);
                     SetPosition(CanMove(newPos));
                 }
                 else if (keyboardInput.KeyChar.Equals('s'))
                 {
                     Coordinate newPos = new Coordinate(position.X, position.Y + 1);
                     SetPosition(CanMove(newPos));
                 }
                 else if (keyboardInput.KeyChar.Equals('d'))
                 {
                     Coordinate newPos = new Coordinate(position.X + 1, position.Y);
                     SetPosition(CanMove(newPos));
                 }
                 else if (keyboardInput.KeyChar.Equals('q'))
                 {
                     Game.exit = true;
                 }
             }
        }
        public void Draw()
        {
            if (position.X < Console.WindowWidth && position.X >= 0 && position.Y < Console.WindowHeight && position.Y >= 0)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Θ");
            }
        }

        public Coordinate CanMove(Coordinate inPos)
        {
            int x = inPos.X - Map.mapOffset.X;
            int y = inPos.Y - Map.mapOffset.Y;
            Debug.WriteLine(x.ToString() + " " + y.ToString());
            for(int row = 0; row < Map.mapCoords.GetLength(0); row++)
            {
                for(int col = 0; col < Map.mapCoords.GetLength(1); col++)
                {
                    if (y == row && x == col && (Map.mapCoords[row, col] != 1 && Map.mapCoords[row, col] != 4))
                    {
                        if (Map.mapCoords[row, col] == 0)
                        {
                            Game.score++;
                            Map.mapCoords[row, col] = 3;
                        }
                        hasMoved = true;
                        return inPos;
                    }
                }
            }
            if (y == Map.mapCoords.GetLength(1) / 2)
            {
                if (x < 0)
                {
                    hasMoved = true;
                    return new Coordinate(Map.mapOffset.X + Map.mapCoords.GetLength(0) - 3, Map.mapOffset.Y + Map.mapCoords.GetLength(1) / 2);
                }
                else if (x >= Map.mapCoords.GetLength(1))
                {
                    hasMoved = true;
                    return new Coordinate(Map.mapOffset.X, Map.mapOffset.Y + Map.mapCoords.GetLength(1) / 2);
                }
            }
            return new Coordinate(-1,-1);
        }

        public Coordinate GetPosition()
        {
            return position;
        }
        public void SetPosition(Coordinate newPos)
        {
            if (newPos.X == -1 && newPos.Y == -1)
                return;

            position = newPos;
        }
        public int GetLives()
        {
            return lives;
        }
        public void SetLives(int inLives)
        {
            lives = inLives;
        }
    }
}
