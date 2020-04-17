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

        public abstract void Rotate();
        public abstract void Update(Cup cup);
        public abstract void Draw();
        public abstract void Stop();
    }
}
