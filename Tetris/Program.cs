using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

using Models;

namespace Tetris
{
    class Program
    {
        // game state
        private static bool isOver;
        private static bool isDrawRequired;

        // time handle
        private static double timeScale = 1;
        private static int estimatedFps;
        private static double timePerFrame;
        
        private static double timeElapsedSinceLastStatisticsUpdate;
        private static double timeToUpdateStatistics;

        private static double timeToMove;
        private static double timeElapsedSinceLastMove;

        // layout
        private static int leftMarginWidth;

        // cup data
        private static int cupWidth;
        private static int cupHeight;
        private static int fallSpeed;
        private static Cup cup;

        // figures data
        private static Figure currentFigure;
        private static Figure nextFigure;

        static int cntr = 0;

        private static void Main(string[] args)
        {
            Init();
            MainLoop();
            Console.WriteLine("Game over. Press enter to exit.");
            Console.Read();
        }

        private static void Init()
        {
            #region game state
            isOver = false;
            isDrawRequired = true;

            #endregion // game state

            #region time
            timeToMove = 0;
            estimatedFps = 60;
            timePerFrame = 1.0 / estimatedFps;
            timeElapsedSinceLastStatisticsUpdate = 0.0;
            timeToUpdateStatistics = 0.7;
            timeElapsedSinceLastMove = 0;

            #endregion // time

            #region layout

            Console.ForegroundColor = ConsoleColor.White;

            leftMarginWidth = 20;

            #endregion // layout

            #region cup initialization
            do
            {
                Console.WriteLine("Field Width: ");
            } while (!int.TryParse(Console.ReadLine(), out cupWidth));

            do
            {
                Console.WriteLine("Field Height: ");
            } while (!int.TryParse(Console.ReadLine(), out cupHeight));

            do
            {
                Console.WriteLine("Fall Speed (squares per minute): ");
            } while (!int.TryParse(Console.ReadLine(), out fallSpeed));

            timeToMove = 60.0 / fallSpeed;

            cup = new Cup(cupWidth, cupHeight, leftMarginWidth);
            #endregion

        }

        private static void MainLoop()
        {
            Timer t = new Timer(1000);
            t.Elapsed += T_Elapsed;
            t.Enabled = true;
            t.Start();

            DateTime prev = DateTime.Now, curr;

            while (!isOver)
            {
                curr = DateTime.Now;
                double deltaTime = (curr - prev).TotalSeconds;
                prev = curr;

                HandleEvents();
                Update(deltaTime);

                if (isDrawRequired)
                {
                    Draw();
                    isDrawRequired = false;
                }
            }
        }

        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            //isDrawRequired = true;
            Console.WriteLine("a second has passed");
        }

        private static void Draw()
        {
            Console.Clear();

            // draw objects
            cup.Draw();
        }

        private static void HandleEvents()
        {
        }

        private static void Update(double deltaTime)
        {
            //UpdateStatistics(deltaTime);

            timeElapsedSinceLastMove += deltaTime;

            if (timeElapsedSinceLastMove > timeToMove)
            {
                timeElapsedSinceLastMove = 0;

                isDrawRequired = true;
            }
                
        }

        private static void UpdateStatistics(double deltaTime)
        {
            timeElapsedSinceLastStatisticsUpdate += deltaTime;

            if (timeElapsedSinceLastStatisticsUpdate >= timeToUpdateStatistics)
            {
                timeElapsedSinceLastStatisticsUpdate = 0.0;
            }
        }
    }
}
