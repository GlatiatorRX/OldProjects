using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Map
    {
        public static Coordinate mapOffset;
        public static int[,] mapCoords;

        public Map()
        {
            mapCoords = new int[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,3,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,1,1,1,0,1,1,1,1,0,1,0,1,1,1,1,0,1,1,1,0,1},
                {1,0,1,1,1,0,1,1,1,1,0,1,0,1,1,1,1,0,1,1,1,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,0,1},
                {1,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,0,0,0,0,1},
                {1,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,1,0,1,1,1,1,1},
                {1,1,1,1,1,0,1,1,1,1,0,1,0,1,1,1,1,0,1,1,1,1,1},
                {1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1},
                {1,1,1,1,1,0,1,0,1,1,1,4,1,1,1,0,1,0,1,1,1,1,1},
                {2,0,0,0,0,0,0,0,1,3,3,3,3,3,1,0,0,0,0,0,0,0,2},
                {1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1},
                {1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1},
                {1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1},
                {1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,1,1,1,0,1,1,1,1,0,1,0,1,1,1,1,0,1,1,1,0,1},
                {1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1},
                {1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,1,1},
                {1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1},
                {1,0,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,0,1},
                {1,0,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };
            mapOffset = new Coordinate(Game.screenCenter.X - mapCoords.GetLength(0) / 2, Game.screenCenter.Y - mapCoords.GetLength(1) / 2);
        }
        public void DrawMap()
        {
            for (int row = 0; row < mapCoords.GetLength(0); row++)
            {
                Console.SetCursorPosition(mapOffset.X, mapOffset.Y + row);

                for (int column = 0; column < mapCoords.GetLength(1); column++)
                {
                    string mapLine = "";
                    switch (mapCoords[row, column])
                    {
                        case 3:
                            {
                                mapLine += " ";
                                break;
                            }
                        case 1:
                            {
                                mapLine += "■";
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            }
                        case 2:
                            {
                                mapLine += " ";
                                break;
                            }
                        case 0:
                            {
                                mapLine += "*";
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case 4:
                            {
                                mapLine += "─"; 
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            }
                    }
                    Console.Write(mapLine);
                }
            }
        }
    }
}
