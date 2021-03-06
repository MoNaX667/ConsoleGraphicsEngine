﻿// <copyright file="Snake.cs" company="Some Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Vitalit Belyakov</author>

namespace ConsoleGraphEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Snake for graphic engine
    /// </summary>
    internal class Snake : Shape
    {
        // Members

        /// <summary>
        /// Body of the snake
        /// </summary>
        private readonly List<Pixel> myBodyesPart;

        // Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Snake" /> class
        /// </summary>
        /// <param name="xStartPos">X start position</param>
        /// <param name="yStartPos">Y start position</param>
        public Snake(int xStartPos, int yStartPos)
        {
            this.myBodyesPart = new List<Pixel>();
            var ran = new Random();

            for (var i = 0; i < 3; i++)
            {
                this.myBodyesPart.Add(new Pixel(
                    xStartPos + i,
                    yStartPos + i,
                    (ConsoleColor)ran.Next(2, 10)));
            }
        }

        /// <summary>
        ///     Draw snake body to graphics frame
        /// </summary>
        public override void Draw()
        {
            var tempColor = Console.ForegroundColor;

            foreach (var value in this.myBodyesPart)
            {
                Console.SetCursorPosition(value.XCoordinate, value.YCoordinate);
                Console.ForegroundColor = value.Color;
                Console.Write('█');
            }

            Console.ForegroundColor = tempColor;
        }

        /// <summary>
        /// Return head pixel
        /// </summary>
        /// <returns>head of the snake</returns>
        public Pixel GetHead()
        {
            return this.myBodyesPart[this.myBodyesPart.Count - 1];
        }

        /// <summary>
        /// Check this snake element for crashing
        /// </summary>
        /// <param name="xStep">X step coordinate</param>
        /// <param name="yStep">Y step coordinate</param>
        /// <returns>return true if all good, else return false</returns>
        public bool CheckMyBodyesForStep(int xStep, int yStep)
        {
            return this.myBodyesPart.All(section => section.XCoordinate != xStep ||
                                               section.YCoordinate != yStep);
        }

        /// <summary>
        /// Do next move: new coordinate was passed for last element in snake body
        /// </summary>
        /// <param name="x">xCoordinate for snake head</param>
        /// <param name="y">yCoordinate for snake head</param>
        public void Move(int x, int y)
        {
            int tempX = 0,
                tempY = 0;

            // Pass coordinate
            for (var i = this.myBodyesPart.Count - 1; i >= 0; i--)
            {
                if (i == this.myBodyesPart.Count - 1)
                {
                    // Head coordinate
                    tempX = this.myBodyesPart[i].XCoordinate;
                    tempY = this.myBodyesPart[i].YCoordinate;
                    this.myBodyesPart[i].XCoordinate = x;
                    this.myBodyesPart[i].YCoordinate = y;
                }
                else
                {
                    // Other body coordinate
                    var temp = this.myBodyesPart[i].XCoordinate;
                    this.myBodyesPart[i].XCoordinate = tempX;
                    tempX = temp;

                    temp = this.myBodyesPart[i].YCoordinate;
                    this.myBodyesPart[i].YCoordinate = tempY;
                    tempY = temp;
                }
            }
        }

        /// <summary>
        /// Add new element to snake body
        /// </summary>
        /// <param name="xCoordinate">X coordinate</param>
        /// <param name="yCoordinate">Y coordinate</param>
        /// <param name="color">Color of pixel</param>
        public void Eat(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            this.myBodyesPart.Add(new Pixel(xCoordinate, yCoordinate, color));
        }
    }
}
