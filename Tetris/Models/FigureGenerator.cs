using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FigureGenerator
    {
        private static Random rand = new Random();


        public static Figure GetRandomFigure(int x, int y, int margin)
        {
            switch(rand.Next(1, 8))
            {
                case 1:
                    return new TFig(x, y, margin);
                case 2:
                    return new IFig(x, y, margin);
                case 3:
                    return new OFig(x, y, margin);
                case 4:
                    return new LFig(x, y, margin);
                case 5:
                    return new JFig(x, y, margin);
                case 6:
                    return new SFig(x, y, margin);
                case 7:
                    return new ZFig(x, y, margin);
            }

            return null;
        }
    }
}
