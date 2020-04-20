using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Figure
    {
        // position
        public int X { get; set; }
        public int Y { get; set; }

        public int LeftMarginWidth { get; set; }

        // figure description
        protected int[,] Points;
        public int Width { get => Points.GetUpperBound(0) + 1; }
        public int Height { get => Points.GetUpperBound(1) + 1; }

        /// <summary>
        /// Occurs when figure cannot fall anymore
        /// </summary>
        public event FigureStateHandler Stopped;
        public delegate void FigureStateHandler(object sender, FigureEventStateArgs e);

        public int this[int i, int j]
        {
            get => Points[i, j];
        }

        public Figure() : this(0, 0)
        { }

        public Figure(int x, int y, int margin = 0)
        {
            X = x;
            Y = y;
            LeftMarginWidth = margin;
        }

        public virtual bool TryRotateRight(Field field)
        {
            int[,] res = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    res[i, j] = Points[Width - 1 - j, i];
                }
            }

            Figure newfig = new Figure() { X = this.X, Y = this.Y, Points = res };
            if (!newfig.TryMove(field, 0, 0))
                return false;

            Points = res;

            return true;
        }

        public virtual bool TryRotateLeft(Field field)
        {
            int[,] res = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    res[i, j] = Points[j, Width - 1 - i];
                }
            }

            Figure newfig = new Figure() { X = this.X, Y = this.Y, Points = res };
            if (!newfig.TryMove(field, 0, 0))
                return false;

            Points = res;

            return true;
        }

        public void Update(Field field)
        {
            // check if we hit something; if so - figure stops
            if (!TryMove(field, 0, 1))
            {
                Stop();
            }
        }

        /// <summary>
        /// Draws the figure on console
        /// </summary>
        public void Draw()
        {
            // +1 is for field boundaries
            ConsoleShapeDrawer.Draw(X + LeftMarginWidth + 1, Y + 1, Points);
        }

        /// <summary>
        /// Moves figure by x columns and y rows if possible
        /// </summary>
        /// <param name="field">field in which the figure is moving</param>
        /// <param name="x">offset in X axis</param>
        /// <param name="y">offset in Y axis</param>
        public bool TryMove(Field field, int x, int y)
        {
            for (int i = 0; i < Width; i++) 
            {
                for (int j = 0; j < Height; j++)
                {
                    int newX = X + x + j;
                    int newY = Y + y + i;

                    if (Points[i, j] != 0 && !field.IsPointEligible(newX, newY)) 
                        return false;
                }
            }

            X += x;
            Y += y;

            return true;
        }

        /// <summary>
        /// Invokes Stopped event of the figure
        /// </summary>
        private void Stop()
        {
            Stopped?.Invoke(this, new FigureEventStateArgs(X, Y));
        }
    }
}
