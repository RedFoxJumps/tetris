using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

using Models;

namespace Tetris
{
    class Program
    {
        // time handle
        private static double timeScale = 1;
        private static bool isOver;
        private static int estimatedFps;
        private static double timePerFrame;
        private static double timeElapsedSinceLastUpdate;
        private static double timeBeforeUpdateStatistics;

        private static void Main(string[] args)
        {
            Init();
            MainLoop();
            Console.WriteLine("Game over. Press enter to exit.");
            Console.Read();
        }

        private static void Init()
        {
            isOver = false;
            estimatedFps = 60;
            timePerFrame = 1.0 / estimatedFps;
            timeElapsedSinceLastUpdate = 0.0;
            timeBeforeUpdateStatistics = 0.7;

        }

        private static void MainLoop()
        {
            Stopwatch globalTimer = new Stopwatch();
            globalTimer.Start();

            while (!isOver)
            {
                double deltaTime = globalTimer.Elapsed.TotalSeconds * timeScale;
                globalTimer.Restart();

                HandleEvents();
                Update(deltaTime);
                Draw();
            }
        }

        private static void Draw()
        {
            Console.Clear();

            // draw objects
        }

        private static void HandleEvents()
        {
        }

        private static void Update(double deltaTime)
        {
            UpdateStatistics(deltaTime);
        }

        private static void UpdateStatistics(double deltaTime)
        {
            timeElapsedSinceLastUpdate += deltaTime;

            if (timeElapsedSinceLastUpdate >= timeBeforeUpdateStatistics)
            {
                timeElapsedSinceLastUpdate = 0.0;

                // draw fps and other stuff
            }
        }
    }
}
