using chess_console.Board;
using System;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);
            Console.WriteLine("Position: " + p);
        }
    }
}
