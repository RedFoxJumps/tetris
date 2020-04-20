using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TFig : Figure
    {

        public TFig() : this(0, 0, 0)
        { }

        public TFig(int x, int y, int margin) : base(1, 1, margin)
        {
            X = x;
            Y = y;  

            Points = new int[3, 3]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 },
            };
        }
    }
}
