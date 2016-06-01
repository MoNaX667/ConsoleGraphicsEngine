// <copyright file="Bunny.cs" company="Some Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Vitalit Belyakov</author>

namespace ConsoleGraphEngine
{
    using System;

    /// <summary>
    /// Bunny for graphics engine
    /// </summary>
    internal class Bunny : Shape
    {
        // Members

        /// <summary>
        /// Randomizer for bunny
        /// </summary>
        private static readonly Random Ran = new Random();

        /// <summary>
        /// Current instance of bunny
        /// </summary>
        private static Bunny myBunny;

        // Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Bunny" /> class
        /// </summary>
        /// <param name="xCoordinate">X coordinate</param>
        /// <param name="yCoordinate">Y coordinate</param>
        /// <param name="color">Color of pixel</param>
        private Bunny(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            this.MyBody = new Pixel(xCoordinate, yCoordinate, color);
        }

        // Properties

        /// <summary>
        /// Gets body of bunny
        /// </summary>
        public Pixel MyBody { get; }

        /// <summary>
        /// Revive bunny with new position
        /// </summary>
        /// <returns>gets bunny</returns>
        public static Bunny GetBunny()
        {
            if (myBunny == null)
            {
                myBunny = new Bunny(Ran.Next(3, 80), Ran.Next(3, 25), (ConsoleColor)Ran.Next(2, 13));
            }
            else
            {
                myBunny.MyBody.XCoordinate = Ran.Next(3, 78);
                myBunny.MyBody.YCoordinate = Ran.Next(3, 25);
                myBunny.MyBody.Color = (ConsoleColor)Ran.Next(2, 13);
            }

            return myBunny;
        }

        /// <summary>
        ///     Draw bunny
        /// </summary>
        public override void Draw()
        {
            var tempColor = Console.ForegroundColor;

            Console.SetCursorPosition(this.MyBody.XCoordinate, this.MyBody.YCoordinate);
            Console.ForegroundColor = this.MyBody.Color;
            Console.Write('⬢');

            Console.ForegroundColor = tempColor;
        }
    }
}
