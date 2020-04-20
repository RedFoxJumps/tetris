using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class ConsoleShapeDrawer
    {
        public const char Square = '■';

        public static void Draw(int xStart, int yStart, int[,] points, char symbol = Square)
        {
            int width = points.GetUpperBound(0) + 1;
            int height = points.GetUpperBound(1) + 1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (points[i, j] == 0)
                        continue;

                    Console.SetCursorPosition(xStart + j, yStart + i);
                    Console.ForegroundColor = GetColor(points[i, j]);
                    Console.Write(symbol);
                }
            }
        }

        private static ConsoleColor GetColor(int value)
        {
            switch (value)
            {
                case 1:
                    return ConsoleColor.Yellow;
                case 2:
                    return ConsoleColor.Red;
                case 3:
                    return ConsoleColor.Magenta;
                case 4:
                    return ConsoleColor.Cyan;
                case 5:
                    return ConsoleColor.Blue;
                case 6:
                    return ConsoleColor.Green;
                case 7:
                    return ConsoleColor.DarkYellow;

                default:
                    return ConsoleColor.White;
            }
        }
    }
}
