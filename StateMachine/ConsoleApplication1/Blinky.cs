using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Blinky : Ghost
    {
        Queue<Coordinate> movementQueue;
        public Blinky(Coordinate inPosition) : base(inPosition)
        {
            movementQueue = new Queue<Coordinate>();
        }

        public void Update()
        {
            if (currentState != State.GhostState.Dead)
            {
                if (Game.score < 5)
                {
                    currentState = State.GhostState.Idle;
                }
                else
                {
                    if (Game.score % 10 == 0)
                    {
                        Game.avoidSW.Start();
                    }
                    if (Game.avoidSW.ElapsedMilliseconds < 10000 && Game.avoidSW.IsRunning) // 10 seconds
                    {
                        currentState = State.GhostState.Running;
                    }
                    else
                    {
                        Game.avoidSW.Stop();
                        Game.avoidSW.Reset();
                        currentState = State.GhostState.Active;
                    }
                }
            }
            /*if(Game.player.hasMoved)
            {
                GetPath();
            }*/
            /*if(movementQueue.Count > 0)
            {
                SetPosition(movementQueue.Dequeue());
            }*/
        }

        public virtual void Draw()
        {
            switch(currentState)
            {
                case State.GhostState.Active:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                case State.GhostState.Idle:
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                }
                case State.GhostState.Running:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                case State.GhostState.Dead:
                {
                    return;
                }
            }
            base.Draw();
        }

        public void GetPath()
        {
            bool path1found = false;
            bool path2found = false;
            int count1 = 0;
            int count2 = 0;
            Coordinate playerPos = Game.player.GetPosition();
            List<Coordinate> movementList1 = new List<Coordinate>();
            List<Coordinate> movementList2 = new List<Coordinate>();
            Coordinate tempPosition1 = position;

            while (!path1found)
            {
                Coordinate temp1 = new Coordinate(-1,-1);
                while (tempPosition1.X < 0 && tempPosition1.Y < 0)
                {
                    /*int testCount = 0;
                    while (testCount)
                    {

                    }
                    tempPosition1 = ShortestDistance(temp1X, temp1Y);
                    movementList1.Add(tempPosition1);
                    count1++;
                    break;*/
                }
                if (tempPosition1 == playerPos)
                {
                    path1found = true;
                }
            }
            while (!path2found)
            {
                Coordinate tempPosition2 = position;
                Coordinate temp2X = new Coordinate(-1, -1);
                Coordinate temp2Y = new Coordinate(-1, -1);
                while ((temp2X.X < 0 && temp2X.Y < 0) && (temp2Y.X < 0 && temp2Y.Y < 0))
                {
                    if (playerPos.X < tempPosition2.X)
                    {
                        temp2X = CanMove(new Coordinate(tempPosition2.X - 1, tempPosition2.Y));
                    }
                    else if (playerPos.X > tempPosition2.X)
                    {
                        temp2X = CanMove(new Coordinate(tempPosition2.X + 1, tempPosition2.Y));
                    }

                    if (playerPos.Y < tempPosition2.Y)
                    {
                        temp2Y = CanMove(new Coordinate(tempPosition2.X, tempPosition2.Y - 1));
                    }
                    else if (playerPos.Y > tempPosition2.Y)
                    {
                        temp2Y = CanMove(new Coordinate(tempPosition2.X, tempPosition2.Y + 1));
                    }

                    if ((temp2X.X < 0 && temp2X.Y < 0) && !(temp2Y.X < 0 && temp2Y.Y < 0))
                    {
                        tempPosition2 = temp2Y;
                        movementList2.Add(tempPosition2);
                        count2++;
                    }
                    else if (!(temp2X.X < 0 && temp2X.Y < 0) && (temp2Y.X < 0 && temp2Y.Y < 0))
                    {
                        tempPosition2 = temp2X;
                        movementList2.Add(tempPosition2);
                        count2++;
                    }
                    else if (!(temp2X.X < 0 && temp2X.Y < 0) && !(temp2Y.X < 0 && temp2Y.Y < 0))
                    {
                        tempPosition2 = ShortestDistance(temp2X, temp2Y);
                        movementList2.Add(tempPosition2);
                        count2++;
                        break;
                    }
                }
                if(tempPosition2 == playerPos)
                {
                    path2found = true;
                }
            }
            if (count1 < count2)
            {
                foreach (Coordinate coord in movementList1)
                {
                    movementQueue.Enqueue(coord);
                }
            }
            else if (count1 >= count2)
            {
                foreach (Coordinate coord in movementList2)
                {
                    movementQueue.Enqueue(coord);
                }
            }
        }

        private Coordinate ShortestDistance(Coordinate co1, Coordinate co2)
        {
            Coordinate playerPos = Game.player.GetPosition();
            int dist1 = (int)Math.Sqrt(Math.Pow(co1.X - playerPos.X, 2) + Math.Pow(co1.Y - playerPos.X, 2));
            int dist2 = (int)Math.Sqrt(Math.Pow(co2.X - playerPos.X, 2) + Math.Pow(co2.Y - playerPos.X, 2));

            if(dist1 < dist2)
            {
                return co1;
            }
            else
            {
                return co2;
            }
        }
    }
}
