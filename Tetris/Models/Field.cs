using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftMarginWidth { get; set; }
        public int[,] Items { get; set; }
        public string LeftMargin => new string(' ', LeftMarginWidth);

        public int this[int x, int y]
        {
            get => Items[x, y];
            set => Items[x, y] = value;
        }

        public Field() : this (0, 0) 
        { }

        public Field(int w, int h, int leftMargin = 0)
        {
            Random r = new Random();

            Width = w;
            Height = h;
            LeftMarginWidth = leftMargin;
            Items = new int[h, w];
        }

        public bool IsPointEligible(int x, int y)
        {
            if (x >= Width || y >= Height || x < 0 || y < 0)
                return false;

            return Items[y, x] == 0;
        }

        /// <summary>
        /// Adds figure to the field
        /// </summary>
        /// <param name="figure"></param>
        public void FillFigure(Figure figure)
        {
            for (int i = 0; i < figure.Height; i++)
            {
                for (int j = 0; j < figure.Width; j++)
                {
                    if ((i + figure.Y) >= Height || (j + figure.X) >= Width)
                        continue;

                    if (figure[i, j] != 0)
                        Items[i + figure.Y, j + figure.X] = figure[i, j];
                }
            }
        }

        /// <summary>
        /// Clears full rows
        /// </summary>
        public void Update()
        {
            
        }

        public void DrawBoundaries()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(LeftMargin + "╓" + new string('—', Width) + "╖");
            for (int i = 0; i < Height; i++)
                Console.WriteLine(LeftMargin + "|" + new string(' ', Width) + "|");

            Console.WriteLine(LeftMargin + "└" + new string('—', Width) + "┘");
        }

        public void DrawField()
        {
            ConsoleShapeDrawer.Draw(LeftMarginWidth + 1, 1, Items);
        }

        public void Draw()
        {
            DrawBoundaries();
            DrawField();
        }

    }
}
