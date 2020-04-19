using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FigureEventStateArgs
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public FigureEventStateArgs()
        { }

        public FigureEventStateArgs(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
