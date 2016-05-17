namespace ConsoleGraphEngine
{
    using System;
    internal class Program
    {
        public static void Main()
        {
            // Console customization
            Console.Title = "Graphic Console Processor";
            Console.CursorVisible = false;

            // Set window params
            Console.WindowHeight = 40;
            Console.WindowWidth = 100;

            AppEngine.Run();
        }
    }
}
