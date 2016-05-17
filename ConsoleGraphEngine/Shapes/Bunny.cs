namespace ConsoleGraphEngine
{
    using System;

    internal class Bunny : Shape
    {
        // Members
        private Pixel myBody;
        private static Random ran = new Random();
        private static Bunny myBunny;

        // Properties
        public Pixel MyBody
        {
            get
            {
                return this.myBody;
            }
        }

        // Constructors
        private Bunny(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            this.myBody = new Pixel(xCoordinate, yCoordinate, color);
        }

        /// <summary>
        /// Draw bunny
        /// </summary>
        public override void Draw()
        {
            ConsoleColor tempColor = Console.ForegroundColor;

            Console.SetCursorPosition(this.myBody.XCoordinate, this.myBody.YCoordinate);
            Console.ForegroundColor = this.myBody.Color;
            Console.Write('⬢');

            Console.ForegroundColor = tempColor;
        }

        /// <summary>
        /// Revive bunny with new position
        /// </summary>
        /// <returns></returns>
        public static Bunny GetBunny()
        {
            if (myBunny == null)
            {
                myBunny = new Bunny(ran.Next(3, 80), ran.Next(3, 25), (ConsoleColor)ran.Next(2, 13));
            }
            else
            {
                myBunny.myBody.XCoordinate = ran.Next(3, 78);
                myBunny.myBody.YCoordinate = ran.Next(3, 25);
                myBunny.myBody.Color = (ConsoleColor)ran.Next(2, 13);
            }

            return myBunny;
        }
    }
}
