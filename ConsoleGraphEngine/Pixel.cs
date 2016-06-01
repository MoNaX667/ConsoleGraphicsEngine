// <copyright file="Pixel.cs" company="Some Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Vitalit Belyakov</author>

namespace ConsoleGraphEngine
{
    using System;

    /// <summary>
    /// Pixel class
    /// </summary>
    internal class Pixel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pixel" /> class
        /// </summary>
        /// <param name="xCoordinate">x coordinate</param>
        /// <param name="yCoordinate">y coordinate</param>
        /// <param name="color">color of pixel</param>
        public Pixel(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Color = color;
        }

        // Properties

        /// <summary>
        /// Gets or sets x coordinate
        /// </summary>
        public int XCoordinate { get; set; }

        /// <summary>
        /// Gets or sets y coordinate
        /// </summary>
        public int YCoordinate { get; set; }

        /// <summary>
        /// Gets or sets color of pixel
        /// </summary>
        public ConsoleColor Color { get; set; }
    }
}
