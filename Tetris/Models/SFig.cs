using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SFig : Figure
    {
        public SFig() : this(0, 0, 0)
        { }

        public SFig(int x, int y, int margin) : base(x, y, margin)
        {
            Points = new int[3, 3]
            {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 1, 1, 0 },
            };
        }
    }
}
