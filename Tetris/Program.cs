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
        private static bool rotateRight;
        private static bool rotateLeft;
        private static ConsoleKey? key = null;
        private static object lockObj = new object();

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
        private static int nextFigureX;
        private static int nextFigureY;

        // cup data
        private static int cupWidth;
        private static int cupHeight;
        private static int fallSpeed;
        private static Field field;

        // figures data
        private static Figure currentFigure;
        private static Figure nextFigure;

        private static void Main(string[] args)
        {
            Init();
            MainLoop();
            Console.WriteLine("Game over. Press enter to exit.");
        }

        private static void Init()
        {
            #region console
            Console.ForegroundColor = ConsoleColor.White;
            #endregion // console

            #region game state

            isOver = false;
            isDrawRequired = true;
            rotateLeft = false;
            rotateRight = false;

            #endregion // game state

            #region time
            timeToMove = 0;
            estimatedFps = 60;
            timePerFrame = 1.0 / estimatedFps;
            timeElapsedSinceLastStatisticsUpdate = 0.0;
            timeToUpdateStatistics = 0.7;
            timeElapsedSinceLastMove = 0;

            #endregion // time

            #region Game field initialization
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

            leftMarginWidth = 20;
            field = new Field(cupWidth, cupHeight, leftMarginWidth);
            #endregion

            #region layout

            Console.CursorVisible = false;
            nextFigureX = field.Width + 2 + 5;
            nextFigureY = 1;

            #endregion // layout

            nextFigure = new TFig(nextFigureX, nextFigureY, leftMarginWidth);
            nextFigure.Stopped += FigureStopped;
            SwapFigures();
        }

        private static void FigureStopped(object sender, FigureEventStateArgs e)
        {
            field.FillFigure(sender as Figure);
            SwapFigures();
        }

        private static void MainLoop()
        {
            Timer t = new Timer { Interval = timeToMove * 1000, Enabled = true };
            t.Elapsed += TimerTick;
            t.Start();

            DateTime prev = DateTime.Now, curr;

            System.Threading.Thread thread = new System.Threading.Thread(HandleEvents) { Name = "KeyPressHandleThread" };
            thread.Start();

            while (!isOver)
            {
                curr = DateTime.Now;
                double deltaTime = (curr - prev).TotalSeconds;
                prev = curr;

                Update(deltaTime);
                if (isDrawRequired)
                {
                    Draw();
                    isDrawRequired = false;
                }
            }

            thread.Abort();
        }

        private static void SwapFigures()
        {
            currentFigure = nextFigure;
            currentFigure.X = field.Width / 2;
            currentFigure.Y = 0;

            nextFigure = new TFig(nextFigureX, nextFigureY, leftMarginWidth);
            nextFigure.Stopped += FigureStopped;
        }

        private static void TimerTick(object sender, ElapsedEventArgs e)
        {
            isDrawRequired = true;
        }

        private static void Draw()
        {
            Console.Clear();

            // draw main field
            field.Draw();

            // next figure
            Console.SetCursorPosition(nextFigureX + leftMarginWidth, nextFigureY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Next figure: ");
            nextFigure.Draw();

            // draw current figure
            currentFigure.Draw();
        }

        private static void HandleEvents()
        {
            while (true)
            {
                key = Console.ReadKey(true).Key;
            }
        }

        private static void HandleKeyPress(ConsoleKey? key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    if (currentFigure.TryRotateLeft(field))
                        isDrawRequired = true;
                    break;
                case ConsoleKey.E:
                    if (currentFigure.TryRotateRight(field))
                        isDrawRequired = true;
                    break;

                case ConsoleKey.A:
                    if (currentFigure.TryMove(field, -1, 0))
                        isDrawRequired = true;
                    break;
                case ConsoleKey.D:
                    if (currentFigure.TryMove(field, 1, 0))
                        isDrawRequired = true;
                    break;

                case ConsoleKey.S:
                    if (currentFigure.TryMove(field, 0, 1))
                        isDrawRequired = true;
                    break;

                default:
                    break;
            }
        }

        private static void Update(double deltaTime)
        {
            timeElapsedSinceLastMove += deltaTime;

            if (key != null)
            {
                HandleKeyPress(key);
                key = null;
            }

            if (timeElapsedSinceLastMove >= timeToMove)
            {
                timeElapsedSinceLastMove = 0;
                isDrawRequired = true;

                field.Update();
                currentFigure.Update(field);
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
