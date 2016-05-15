using System;

namespace ConsoleGraphEngine
{
    class Pixel
    {
        // Members
        private int xCoordinate;
        private int yCoordinate;
        private ConsoleColor color;

        // Properties
        public int XCoordinate {
            get {
                return xCoordinate;
            }
            set {
                xCoordinate = value;
            }
        }

        public int YCoordinate {
            get {
                return yCoordinate;
            }
            set {
                yCoordinate = value;
            }
        }

        public ConsoleColor Color {
            get {
                return color;
            }
            set {
                color = value;
            }
        }

        // Constructors
        public Pixel(int xCoordinate,int yCoordinate,ConsoleColor color)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.color = color;
        }


    }
}
