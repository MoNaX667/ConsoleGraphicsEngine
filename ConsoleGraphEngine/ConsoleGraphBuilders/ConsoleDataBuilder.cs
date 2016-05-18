using System;

namespace ConsoleGraphEngine
{
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
