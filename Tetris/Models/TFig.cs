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
            FigureColor = ConsoleColor.Yellow;

            X = x;
            Y = y;  

            Points = new int[3, 3]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 },
            };
        }

        public override void Draw()
        {
            Console.ForegroundColor = FigureColor;
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Columns; j++)  
                {
                    if (Points[i, j] == 0)
                        continue;

                    Console.CursorLeft = X + LeftMarginWidth + j + 1;
                    Console.CursorTop = Y + i + 1;
                    Console.Write(Square);
                }
            }
        }

        public override void Update(Cup cup)
        {
            Y += 1;
            RotateRight();
        }
    }
}
