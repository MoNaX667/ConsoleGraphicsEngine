using System;

namespace ConsoleGraphEngine
{
    class Pixel
    {
        // Members

        // Properties
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public ConsoleColor Color { get; set; }

        // Constructors
        public Pixel(int xCoordinate,int yCoordinate,ConsoleColor color)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Color = color;
        }


    }
}
