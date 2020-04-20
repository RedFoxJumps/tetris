using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LFig : Figure
    {
        public LFig() : this(0, 0, 0)
        { }

        public LFig(int x, int y, int margin) : base(x, y, margin)
        {
            Points = new int[3, 3]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 1, 0, 0 },
            };
        }
    }
}
