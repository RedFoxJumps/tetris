using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TFig : Figure
    {
        public TFig() : this (0)
        { }

        public TFig(int margin) : base(1, 1, margin)
        {
            FigureColor = ConsoleColor.Yellow;

            Points = new int[4, 4]
            {
                { 0, 0, 0, 0 },
                { 1, 1, 1, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 0 }
            };
        }

        public override void Draw()
        {

        }

        public override void Rotate()
        {
        }

        public override void Stop()
        {

        }

        public override void Update(Cup cup)
        {

        }
    }
}
