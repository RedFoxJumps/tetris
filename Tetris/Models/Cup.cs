using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Cup
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftMarginWidth { get; set; }
        public bool[,] Items { get; set; }
        public string LeftMargin => new string(' ', LeftMarginWidth);

        public Cup() : this (0, 0) 
        { }

        public Cup(int w, int h, int leftMargin = 0)
        {
            Width = w;
            Height = h;
            LeftMarginWidth = leftMargin;
            Items = new bool[w, h];
        }

        public void Draw()
        {
            Console.WriteLine(LeftMargin + "┌" + new string(' ', Width) + "┐");
            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine(LeftMargin + "|" + new string(' ', Width) + "|");
            }
            Console.WriteLine(LeftMargin + "└" + new string('-', Width) + "┘");
        }

    }
}
