using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ZFig : Figure
    {
        public ZFig() : this(0, 0, 0)
        { }

        public ZFig(int x, int y, int margin) : base(x, y, margin)
        {
            Points = new int[3, 3]
            {
                { 0, 0, 0 },
                { 7, 7, 0 },
                { 0, 7, 7 },
            };
        }
    }
}
