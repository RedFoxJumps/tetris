using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class IFig : Figure
    {
        public IFig() : this(0, 0, 0)
        { }

        public IFig(int x, int y, int margin) : base(x, y, margin)
        {
            Points = new int[4, 4]
            {
                { 0, 0, 0, 0 },
                { 2, 2, 2, 2 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
        }
    }
}
