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

        public int[,] Points;
        public int Rows => Points.GetUpperBound(0) + 1;
        public int Columns => Points.GetUpperBound(1) + 1;

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

        public void RotateRight()
        {
            for (int i = 0; i < Rows / 2; i++)
            {
                for (int j = i; j < Rows - i - 1; j++)
                {
                    int temp = Points[i, j];

                    Points[i, j] = Points[Rows - 1 - j, i];
                    Points[Rows - 1 - j, i] = Points[Rows - 1 - i, Rows - 1 - j];
                    Points[Rows - 1 - i, Rows - 1 - j] = Points[j, Rows - 1 - i];
                    Points[j, Rows - 1 - i] = temp;
                }
            }
        }

        public void RotateLeft()
        {
            for (int i = 0; i < Rows / 2; i++)
            {
                for (int j = i; j < Rows - i - 1; j++)
                {
                    int temp = Points[i, j];

                    // move values from right to top 
                    Points[i, j] = Points[j, Rows - 1 - i];
                    // move values from bottom to right 
                    Points[j, Rows - 1 - i] = Points[Rows - 1 - i, Rows - 1 - j];
                    // move values from left to bottom 
                    Points[Rows - 1 - i, Rows - 1 - j] = Points[Rows - 1 - j, i];
                    // assign temp to left 
                    Points[Rows - 1 - j, i] = temp;
                }
            }
        }

        public abstract void Update(Cup cup);
        public abstract void Draw();
        //public abstract void Stop();
    }
}
