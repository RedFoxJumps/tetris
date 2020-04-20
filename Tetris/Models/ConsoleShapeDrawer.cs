using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class ConsoleShapeDrawer
    {
        public static void Draw(int xStart, int yStart, int[,] points, ConsoleColor color, char symbol)
        {
            int width = points.GetUpperBound(0) + 1;
            int height = points.GetUpperBound(1) + 1;

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
