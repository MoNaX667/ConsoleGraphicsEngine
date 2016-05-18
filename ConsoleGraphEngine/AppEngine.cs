using System;
using System.Threading;

namespace ConsoleGraphEngine
{
    internal static class AppEngine
    {
        /// <summary>
        ///     Start engine
        /// </summary>
        public static void Run()
        {
            // Build user inteface
            DrawUserInterface();

            Console.SetCursorPosition(3, 32);
            Console.Write("Press Esc to stop animation");

            // Run animation
            RunSnakeAnimation();

            ConsoleDataBuilder.ClearGrapfField();
            Console.SetCursorPosition(22, 14);
            Console.Write("App will be end ... Press Enter to Exit");
            Console.SetCursorPosition(3, 32);
            Console.Write(new string(' ', 30));
            var tempKey = new ConsoleKeyInfo();

            // Exit block
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(3, 32);

                    tempKey = Console.ReadKey();

                    if (tempKey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    Console.SetCursorPosition(3, 32);
                    Console.Write(new string(' ', 30));
                }
            }
        }

        /// <summary>
        ///     CheckEat to next move
        /// </summary>
        /// <param name="mySnake"></param>
        /// <param name="myBunny"></param>
        /// <returns></returns>
        private static bool CheckEat(Snake mySnake, Bunny myBunny)
        {
            if ((mySnake.GetHead().XCoordinate == myBunny.MyBody.XCoordinate) &&
                (mySnake.GetHead().YCoordinate == myBunny.MyBody.YCoordinate))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Build GIU and frame programm blocks
        /// </summary>
        private static void DrawUserInterface()
        {
            // Draw frames
            ConsoleFrameBuilder.DrawBaseFrame(0, 0, 30, 98);
            ConsoleFrameBuilder.DrawAnimationFrame();
        }

        /// <summary>
        ///     RunSnakeAnimation
        /// </summary>
        private static void RunSnakeAnimation()
        {
            var ran = new Random();
            var keyConsole = new ConsoleKeyInfo();

            // Create animation objects
            var mySnake = new Snake(ran.Next(15, 60), ran.Next(4, 20));
            var myBunny = Bunny.GetBunny();

            // Animation block
            while (true)
            {
                // Clear graph frame
                ConsoleDataBuilder.ClearGrapfField();

                // Output image
                myBunny.Draw();
                mySnake.Draw();

                // Calculate next Move and done it
                int nextXStep;
                int nextYStep;
                CalculateNextSnakeMove(out nextXStep, out nextYStep, mySnake, myBunny);

                // Check for eating...
                if (CheckEat(mySnake, myBunny))
                {
                    // if bunny eating do new bunny position and draw it...
                    mySnake.Eat(nextXStep, nextYStep, myBunny.MyBody.Color);
                    myBunny = Bunny.GetBunny();
                    myBunny.Draw();
                    mySnake.Draw();
                }
                else
                {
                    // ...than do snake move
                    mySnake.Move(nextXStep, nextYStep);
                }

                Thread.Sleep(50);


                if (Console.KeyAvailable)
                {
                    keyConsole = Console.ReadKey();

                    if (keyConsole.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Calculate new coordinate to next move for snake
        /// </summary>
        private static void CalculateNextSnakeMove(
            out int x,
            out int y,
            Snake mySnake,
            Bunny myBunny)
        {
            // Head coodinate for cheking
            var xSnakeHead = mySnake.GetHead().XCoordinate;
            var ySnakeHead = mySnake.GetHead().YCoordinate;
            int xResult = xSnakeHead, yResult = ySnakeHead;

            // Check for any move 
            // If next does not strike snake body and do next position more closer with bunny
            // than return new coordinats
            if (mySnake.CheckMyBodyesForStep(xResult + 1, yResult) &&
                CheckVector(mySnake, myBunny, xResult + 1, yResult))
            {
                x = xResult + 1;
                y = yResult;
                return;
            }
            if (mySnake.CheckMyBodyesForStep(xResult, yResult + 1) &&
                CheckVector(mySnake, myBunny, xResult, yResult + 1))
            {
                x = xResult;
                y = yResult + 1;
                return;
            }
            if (mySnake.CheckMyBodyesForStep(xResult - 1, yResult) &&
                CheckVector(mySnake, myBunny, xResult - 1, yResult))
            {
                x = xResult - 1;
                y = yResult;
                return;
            }
            if (mySnake.CheckMyBodyesForStep(xResult, yResult - 1) &&
                CheckVector(mySnake, myBunny, xResult, yResult - 1))
            {
                x = xResult;
                y = yResult - 1;
                return;
            }

            x = xResult;
            y = yResult;
        }

        /// <summary>
        ///     Check equils new coordinate ith old position for good relust
        /// </summary>
        /// <param name="mySnake">mySnake</param>
        /// <param name="myBunny">myBunny</param>
        /// <param name="xStep">new x coordinate</param>
        /// <param name="yStep">new y coordinate</param>
        /// <returns></returns>
        private static bool CheckVector(Snake mySnake, Bunny myBunny, int xStep, int yStep)
        {
            // Calculate old vector lenght
            var baseLenght = Math.Sqrt(Math.Pow(
                myBunny.MyBody.XCoordinate - mySnake.GetHead().XCoordinate, 2) +
                                       Math.Pow(myBunny.MyBody.YCoordinate - mySnake.GetHead().YCoordinate, 2));

            // Calculate new vector lenght
            var nextLenght = Math.Sqrt(Math.Pow(myBunny.MyBody.XCoordinate - xStep, 2) +
                                       Math.Pow(myBunny.MyBody.YCoordinate - yStep, 2));

            // If next lenght less that current position lenght than move is good
            if (baseLenght > nextLenght)
            {
                return true;
            }

            return false;
        }
    }
}
