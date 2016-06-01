// <copyright file="ConsoleDataBuilder.cs" company="Some Company">
// Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
// <author>Vitalit Belyakov</author>

namespace ConsoleGraphEngine
{
    using System;

    /// <summary>
    /// Console data builder
    /// </summary>
    internal static class ConsoleDataBuilder
    {
        /////////////////////////// Public methods //////////////////////////////

        /// <summary>
        ///     Clean graphic frame
        /// </summary>
        public static void ClearGrapfField()
        {
            for (var i = 3; i < 29; i++)
            {
                Console.SetCursorPosition(3, i);
                Console.Write(new string(' ', 78));
            }
        }
    }
}
