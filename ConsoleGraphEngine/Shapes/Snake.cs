﻿using System;
using System.Collections.Generic;

namespace ConsoleGraphEngine
{
    class Snake:Shape
    {
        // Members
        private List<Pixel> myBodyesPart;

        // Properties
        
        // Constructors
        public Snake(int xStartPos,int yStartPos)
        {
            myBodyesPart = new List<Pixel>();

            Random ran = new Random();

            for (int i = 0; i < 3; i++) {
                myBodyesPart.Add(new Pixel(xStartPos +i, yStartPos+i, 
                    (ConsoleColor)ran.Next(2, 10)));
            }
        }

        // Methods

        /// <summary>
        /// Draw snake body to graphics frame
        /// </summary>
        public override void Draw()
        {
            ConsoleColor tempColor = Console.ForegroundColor;

            foreach (Pixel value in myBodyesPart) {
                Console.SetCursorPosition(value.XCoordinate, value.YCoordinate);
                Console.ForegroundColor = value.Color;
                Console.Write('█');
            }

            Console.ForegroundColor = tempColor;
        }


        public void Eat() {

        }

        /// <summary>
        /// Return head pixel
        /// </summary>
        /// <returns></returns>
        public Pixel GetHead() {
            return myBodyesPart[myBodyesPart.Count - 1];
        }

        /// <summary>
        /// Check bodyes element for crashing
        /// </summary>
        /// <param name="xStep"></param>
        /// <param name="yStep"></param>
        /// <returns>return true if all good, else return false</returns>
        public bool CheckMyBodyesForStep(int xStep,int yStep) {

            foreach (Pixel section in myBodyesPart) {
                if (section.XCoordinate == xStep && section.YCoordinate == yStep)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Do next move: new coordinate was passed for last element in snake body
        /// </summary>
        /// <param name="x">xCoordinate for snake head</param>
        /// <param name="y">yCoordinate for snake head</param>
        public void Move(int x, int y) {
            int tempX = 0, tempY = 0;int temp = 0;

            for (int i = myBodyesPart.Count - 1; i >=0; i--) {

                if (i == myBodyesPart.Count - 1)
                {
                    tempX = myBodyesPart[i].XCoordinate;
                    tempY = myBodyesPart[i].YCoordinate;
                    myBodyesPart[i].XCoordinate = x;
                    myBodyesPart[i].YCoordinate = y;
                }
                else {
                    temp = myBodyesPart[i].XCoordinate;
                    myBodyesPart[i].XCoordinate = tempX;
                    tempX = temp;

                    temp = myBodyesPart[i].YCoordinate;
                    myBodyesPart[i].YCoordinate = tempY;
                    tempY = temp;
                }

            }
        }
        
        // Private method

        /// <summary>
        /// Add new element to snake body
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="color"></param>
        private void Grow(int xCoordinate,int yCoordinate,ConsoleColor color) {
            myBodyesPart.Add(new Pixel(xCoordinate,yCoordinate,color));
        }
    }
}