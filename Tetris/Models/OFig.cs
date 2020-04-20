using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OFig : Figure
    {
        public OFig() : this(0, 0, 0)
        { }

        public OFig(int x, int y, int margin) : base(x, y, margin)
        {
            Points = new int[2, 2]
            {
                { 1, 1 },
                { 1, 1 }
            };
        }

        public override bool TryRotateLeft(Field field)
        {
            return true;
        }

        public override bool TryRotateRight(Field field)
        {
            return true;
        }
    }
}
