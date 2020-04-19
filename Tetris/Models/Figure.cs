using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Figure
    {
        // center of rotation
        public int CX { get; set; }
        public int CY { get; set; }

        // position
        public int X { get; set; }
        public int Y { get; set; }

        public int LeftMarginWidth { get; set; }
        public ConsoleColor FigureColor { get; set; }

        // figure description
        public int[,] Points;
        public int Width { get => Points.GetUpperBound(0) + 1; }
        public int Height { get => Points.GetUpperBound(1) + 1; }

        public char Square => '■';

        public int this[int i, int j]
        {
            get => Points[i, j];
        }

        public Figure() : this(0, 0)
        { }

        public Figure(int cx, int cy, int margin = 0, int x = 0, int y = 0)
        {
            CX = cx;
            CY = cy;
            X = x;
            Y = y;
            LeftMarginWidth = margin;
        }

        public bool TryRotateRight(Field field)
        {
            for (int i = 0; i < Width / 2; i++)
            {
                for (int j = i; j < Width - i - 1; j++)
                {
                    int temp = Points[i, j];

                    Points[i, j] = Points[Width - 1 - j, i];
                    Points[Width - 1 - j, i] = Points[Width - 1 - i, Width - 1 - j];
                    Points[Width - 1 - i, Width - 1 - j] = Points[j, Width - 1 - i];
                    Points[j, Width - 1 - i] = temp;
                }
            }

            return true;
        }

        public bool TryRotateLeft(Field field)
        {
            for (int i = 0; i < Width / 2; i++)
            {
                for (int j = i; j < Width - i - 1; j++)
                {
                    int temp = Points[i, j];

                    // move values from right to top 
                    Points[i, j] = Points[j, Width - 1 - i];
                    // move values from bottom to right 
                    Points[j, Width - 1 - i] = Points[Width - 1 - i, Width - 1 - j];
                    // move values from left to bottom 
                    Points[Width - 1 - i, Width - 1 - j] = Points[Width - 1 - j, i];
                    // assign temp to left 
                    Points[Width - 1 - j, i] = temp;
                }
            }

            return true;
        }

        public void Update(Field field)
        {
            // check if we hit something; if so - figure stops
            if (!TryMove(field, 0, 1))
            {
                Stop();
            }
        }

        /// <summary>
        /// Draws the figure on console
        /// </summary>
        public void Draw()
        {
            Console.ForegroundColor = FigureColor;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Points[i, j] == 0)
                        continue;

                    Console.CursorLeft = X + LeftMarginWidth + j + 1;
                    Console.CursorTop = Y + i + 1;
                    Console.Write(Square);
                }
            }
        }

        public bool TryMove(Field field, int x, int y)
        {
            X += x;
            Y += y;

            return true;
        }

        public void Stop()
        { 
            
        }
    }
}
