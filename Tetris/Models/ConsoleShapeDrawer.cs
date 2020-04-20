using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class ConsoleShapeDrawer
    {
        public static void Draw(int xStart, int yStart, int[,] points, char symbol)
        {
            int width = points.GetUpperBound(0) + 1;
            int height = points.GetUpperBound(1) + 1;

            ConsoleColor color;

            switch(points[1,1])
            {
                case 1:
                    color = ConsoleColor.Yellow;
                    break;
                case 2:
                    color = ConsoleColor.Red;
                    break;
                case 3:
                    color = ConsoleColor.Magenta;
                    break;
                case 4:
                    color = ConsoleColor.Cyan;
                    break;
                case 5:
                    color = ConsoleColor.Blue;
                    break;
                case 6:
                    color = ConsoleColor.Green;
                    break;
                case 7:
                    color = ConsoleColor.DarkYellow;
                    break;

                default:
                    color = ConsoleColor.White;
                    break;
            }

            Console.ForegroundColor = color;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (points[i, j] == 0)
                        continue;

                    Console.SetCursorPosition(xStart + j, yStart + i);
                    Console.Write(symbol);
                }
            }
        }
    }
}
