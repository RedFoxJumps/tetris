using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cup
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftMarginWidth { get; set; }
        public int[,] Items { get; set; }
        public string LeftMargin => new string(' ', LeftMarginWidth);

        public List<Figure> Figures { get; set; }


        public int this[int i, int j]
        {
            get => Items[i, j];
            set => Items[i, j] = value;
        }

        public Cup() : this (0, 0) 
        { }

        public Cup(int w, int h, int leftMargin = 0)
        {
            Width = w;
            Height = h;
            LeftMarginWidth = leftMargin;
            Items = new int[w, h];

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
