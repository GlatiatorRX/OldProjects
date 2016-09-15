using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Ghost
    {
        public Coordinate position;
        public State.GhostState currentState;
        public Ghost(Coordinate inPosition)
        {
            position = inPosition;
            currentState = State.GhostState.Idle;
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
        public State.GhostState GetState()
        {
            return currentState;
        }
        public void SetState(State.GhostState newState)
        {
            currentState = newState;
        }
        public virtual void Draw()
        {
            if (position.X < Console.WindowWidth && position.X >= 0 && position.Y < Console.WindowHeight && position.Y >= 0)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.WriteLine("Ω");
            }
        }
        public Coordinate CanMove(Coordinate inPos)
        {
            int x = inPos.X - Map.mapOffset.X;
            int y = inPos.Y - Map.mapOffset.Y;
            for (int row = 0; row < Map.mapCoords.GetLength(0); row++)
            {
                for (int col = 0; col < Map.mapCoords.GetLength(1); col++)
                {
                    if (y == row && x == col && Map.mapCoords[row, col] != 1)
                    {
                        return inPos;
                    }
                }
            }
            return new Coordinate(-1, -1);
        }
    }
}
