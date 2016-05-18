using System;

namespace ConsoleGraphEngine
{
    internal class Bunny : Shape
    {
        // Members
        private static readonly Random ran = new Random();
        private static Bunny myBunny;

        // Properties
        public Pixel MyBody { get; }

        // Constructors
        private Bunny(int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            MyBody = new Pixel(xCoordinate, yCoordinate, color);
        }

        /// <summary>
        ///     Draw bunny
        /// </summary>
        public override void Draw()
        {
            var tempColor = Console.ForegroundColor;

            Console.SetCursorPosition(MyBody.XCoordinate, MyBody.YCoordinate);
            Console.ForegroundColor = MyBody.Color;
            Console.Write('⬢');

            Console.ForegroundColor = tempColor;
        }

        /// <summary>
        ///     Revive bunny with new position
        /// </summary>
        /// <returns></returns>
        public static Bunny GetBunny()
        {
            if (myBunny == null)
            {
                myBunny = new Bunny(ran.Next(3, 80), ran.Next(3, 25), (ConsoleColor) ran.Next(2, 13));
            }
            else
            {
                myBunny.MyBody.XCoordinate = ran.Next(3, 78);
                myBunny.MyBody.YCoordinate = ran.Next(3, 25);
                myBunny.MyBody.Color = (ConsoleColor) ran.Next(2, 13);
            }

            return myBunny;
        }
    }
}
