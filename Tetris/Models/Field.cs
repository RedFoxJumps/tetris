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
            Width = w;
            Height = h;
            LeftMarginWidth = leftMargin;
            Items = new int[w, h];

        }

        public bool IsPointEligible(int x, int y)
        {
            if (x > Width || y > Height || x < 0 || y < 0)
                return false;

            return Items[x, y] == 0;
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(LeftMargin + "┌" + new string('—', Width) + "┐");
            for (int i = 0; i < Height; i++)
                Console.WriteLine(LeftMargin + "|" + new string(' ', Width) + "|");

            Console.WriteLine(LeftMargin + "└" + new string('—', Width) + "┘");
        }

    }
}
