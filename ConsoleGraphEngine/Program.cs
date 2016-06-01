// <copyright file="Program.cs" company="Some Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Vitalit Belyakov</author>

namespace ConsoleGraphEngine
{
    using System;

    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method
        /// </summary>
        public static void Main()
        {
            // Console customization
            Console.Title = "Graphic Console Processor";
            Console.CursorVisible = false;

            // Set window params
            Console.WindowHeight = 40;
            Console.WindowWidth = 100;

            AppEngine.Run();
        }
    }
}
