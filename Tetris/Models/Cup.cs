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

        public Cup() : this (0, 0) 
        { }

        public Cup(int w, int h, int leftMargin = 0)
        {
            Items = new bool[w, h];
        }

        private void DrawMargin()
        {
            Console.Write(new string(' ', LeftMarginWidth));
        }

        public void Draw()
        {
            Console.WriteLine('┌' + new string(' ', Width) + '┐');
            for (int i = 0; i < Height; i++)
            {
                DrawMargin();
                Console.WriteLine('|' + new string(' ', Width) + '|');
            }
            Console.WriteLine('└' + new string('_', Width) + '┘');
        }

    }
}
