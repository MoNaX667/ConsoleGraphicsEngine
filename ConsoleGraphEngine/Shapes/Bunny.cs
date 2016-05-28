namespace ConsoleGraphEngine
{
    using System;

    internal class Bunny : Shape
    {
        // Members
        private static readonly Random ran = new Random();
        private static Bunny myBunny;

        // Constructors
        private Bunny(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            this.MyBody = new Pixel(xCoordinate, yCoordinate, color);
        }

        // Properties
        public Pixel MyBody { get; }

        /// <summary>
        /// Revive bunny with new position
        /// </summary>
        /// <returns>gets bunny</returns>
        public static Bunny GetBunny()
        {
            if (myBunny == null)
            {
                myBunny = new Bunny(ran.Next(3, 80), ran.Next(3, 25), (ConsoleColor)ran.Next(2, 13));
            }
            else
            {
                myBunny.MyBody.XCoordinate = ran.Next(3, 78);
                myBunny.MyBody.YCoordinate = ran.Next(3, 25);
                myBunny.MyBody.Color = (ConsoleColor)ran.Next(2, 13);
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
