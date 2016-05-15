using System;
using System.Threading;

namespace ConsoleGraphEngine
{
    static class AppEngine
    {
        public static void Run() {
            RunSnakeAnimation();
        }

        /// <summary>
        /// Build GIU and frame programm blocks
        /// </summary>
        private static void DrawUserInterface() {

        }

        /// <summary>
        /// RunSnakeAnimation
        /// </summary>
        private static void RunSnakeAnimation() {
            int nextXStep = 0, nextYStep = 0;
            Random ran = new Random();
            
            // Create animation objects
            Snake mySnake = new Snake(ran.Next(15,80),ran.Next(4,20));
            Bunny myBunny = Bunny.GetBunny();

            bool bunnyWasEaten = false;

            // Animation block
            while (true) {
                
                // Eaten flag check if bunny was eaten create new bunny
                if (bunnyWasEaten) {
                    myBunny = Bunny.GetBunny();
                }

                // Clear graph frame
                ConsoleDataBuilder.ClearGrapfField();
                Thread.Sleep(200);

                // Output image
                myBunny.Draw();
                mySnake.Draw();

                // Calculate next Move and done it
                CalculateNextSnakeMove(out nextXStep,out nextYStep,mySnake,myBunny);
                mySnake.Move(nextXStep,nextYStep);
                Thread.Sleep(500);


            }
            

        }

        /// <summary>
        /// Calculate new coordinate to next move for snake
        /// </summary>
        private static void CalculateNextSnakeMove(out int x, out int y,
            Snake mySnake, Bunny myBunny)
        {
            int xSnakeHead = mySnake.GetHead().XCoordinate;
            int ySnakeHead = mySnake.GetHead().YCoordinate;
            int xResult =xSnakeHead , yResult = ySnakeHead;

            if (mySnake.CheckMyBodyesForStep(xResult + 1, yResult) &&
                CheckVector(mySnake, myBunny))
            {
                x = xResult + 1;
                y = yResult;
                return;
            }
            else if (mySnake.CheckMyBodyesForStep(xResult, yResult + 1) &&
                CheckVector(mySnake, myBunny))
            {
                x = xResult;
                y = yResult + 1;
                return;
            }
            else if (mySnake.CheckMyBodyesForStep(xResult - 1, yResult) &&
                CheckVector(mySnake, myBunny))
            {
                x = xResult - 1;
                y = yResult;
                return;
            }
            else if (mySnake.CheckMyBodyesForStep(xResult, yResult-1) &&
               CheckVector(mySnake, myBunny)) {
                x = xResult;
                y = yResult-1;
                return;
            }

            x = xResult;
            y = yResult;
        }

        private static bool CheckVector(Snake mySnake, Bunny myBunny) {
            return true;
        }
    }
}
