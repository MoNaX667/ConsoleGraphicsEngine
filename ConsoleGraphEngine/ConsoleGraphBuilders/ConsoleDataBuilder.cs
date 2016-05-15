using System;

namespace ConsoleGraphEngine
{
    static class ConsoleDataBuilder
    {
        /////////////////////////// Public methods //////////////////////////////
        /// <summary>
        /// Clean graphic frame
        /// </summary>
        public static void ClearGrapfField() {
            Console.SetCursorPosition(3,3);
            for (int i = 3; i < 30; i++) {
                Console.WriteLine(new string(' ',80));
            }
        }

        /// <summary>
        /// Drawing programm structure
        /// </summary>
        public static void DrawAppFrames() {
            DrawFrame(0,0,40,99);
        }

        /////////////////////////// Private methods //////////////////////////////
        /// <summary>
        /// Draw simple frame
        /// </summary>
        /// <param name="startHeight"></param>
        /// <param name="startWidth"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        private static void DrawFrame(int startHeight, int startWidth, int height, int width)
        {

            // Top horizontal line
            Console.SetCursorPosition(startWidth, startHeight);
            Console.Write('\u250c');
            Console.Write(new string('\u2500', width - startWidth));
            Console.Write('\u2510');

            // bottom horizontal line
            Console.SetCursorPosition(startWidth, height);
            Console.Write('\u2514');
            Console.Write(new string('\u2500', width - startWidth));
            Console.Write('\u2518');

            // left vertical line
            for (int i = height - 1; i > startHeight; i--)
            {
                Console.SetCursorPosition(startWidth, i);
                Console.Write('\u2502');
            }

            // right vertical line
            for (int i = height - 1; i > startHeight; i--)
            {
                Console.SetCursorPosition(width + 1, i);
                Console.Write('\u2502');
            }
        }
    }
}
