﻿using System;

namespace ConsoleGraphEngine
{
    class Program
    {
        static void Main(string[] args)
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