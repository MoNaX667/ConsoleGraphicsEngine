namespace ConsoleGraphEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Snake: Shape
    {
        // Members
        private List<Pixel> myBodyesPart;
        
        // Constructors
        public Snake(int xStartPos, int yStartPos)
        {
            this.myBodyesPart = new List<Pixel>();

            Random ran = new Random();

            for (int i = 0; i < 3; i++)
            {
                myBodyesPart.Add(new Pixel(xStartPos + i, yStartPos + i, 
                    (ConsoleColor)ran.Next(2, 10)));
            }
        }

        /// <summary>
        /// Draw snake body to graphics frame
        /// </summary>
        public override void Draw()
        {
            ConsoleColor tempColor = Console.ForegroundColor;

            foreach (Pixel value in myBodyesPart)
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
        /// <returns></returns>
        public Pixel GetHead()
        {
            return this.myBodyesPart[myBodyesPart.Count - 1];
        }

        /// <summary>
        /// Check bodyes element for crashing
        /// </summary>
        /// <param name="xStep"></param>
        /// <param name="yStep"></param>
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
            for (int i = this.myBodyesPart.Count - 1; i >= 0; i--)
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
        /// <param name="xCoordinate">X</param>
        /// <param name="yCoordinate">Y</param>
        /// <param name="color">color</param>
        public void Eat(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            this.myBodyesPart.Add(new Pixel(xCoordinate, yCoordinate, color));
        }
    }
}
