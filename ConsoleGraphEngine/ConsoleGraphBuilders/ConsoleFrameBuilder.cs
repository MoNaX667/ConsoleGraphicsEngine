// <copyright file="ConsoleFrameBuilder.cs" company="Some Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Vitalit Belyakov</author>

namespace ConsoleGraphEngine
{
    using System;

    /// <summary>
    /// Console frame builder
    /// </summary>
    internal static class ConsoleFrameBuilder
    {
        /// <summary>
        /// Draw simple frame
        /// </summary>
        /// <param name="startHeight">start height</param>
        /// <param name="startWidth">start width</param>
        /// <param name="height">target height</param>
        /// <param name="width">target width</param>
        public static void DrawBaseFrame(int startHeight, int startWidth, int height, int width)
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
            for (var i = height - 1; i > startHeight; i--)
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

        /// <summary>
        /// Draw animation frame
        /// </summary>
        public static void DrawAnimationFrame()
        {
            DrawBaseFrame(1, 1, 29, 80);

            Console.SetCursorPosition(30, 1);
            Console.Write(" Animation block ");
        }
    }
}
