using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Figure
    {
        // center of rotation and position
        public int X { get; set; }
        public int Y { get; set; }

        public Figure() : this(0, 0) 
        { }

        public Figure(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Rotate();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Stop();
    }
}
