using System;

namespace ConsoleGraphEngine
{
    class Bunny:Shape
    {
        // Members
        private Pixel myBody;
        private static Random ran = new Random();
        private static Bunny myBunny;

        // Properties
        public Pixel MyBody {
            get {
                return myBody;
            }
        }

        // Constructors
        private Bunny(int xCoordinate,int yCoordinate,ConsoleColor color){
            this.myBody = new Pixel(xCoordinate, yCoordinate, color);
        }

        // Methods

        /// <summary>
        /// Draw bunny
        /// </summary>
        public override void Draw()
        {
            ConsoleColor tempColor = Console.ForegroundColor;

            Console.SetCursorPosition(myBody.XCoordinate, myBody.YCoordinate);
            Console.ForegroundColor = myBody.Color;
            Console.Write('⬢');

            Console.ForegroundColor = tempColor;
        }

        public static Bunny GetBunny() {
            if (myBunny == null)
            {
                myBunny = new Bunny(ran.Next(3, 80), ran.Next(3, 25), (ConsoleColor)ran.Next(2, 13));
            }
            else {
                myBunny.myBody.XCoordinate = ran.Next(3, 80);
                myBunny.myBody.YCoordinate = ran.Next(3, 25);
                myBunny.myBody.Color = (ConsoleColor)ran.Next(2, 13);

            }

            return myBunny;
        }

        // Private methods
    }
}
