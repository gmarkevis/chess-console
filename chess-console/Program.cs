using System;
using chess_console.board;
using chess_console.chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition chessPosition = new ChessPosition('a', 1);
            Console.WriteLine(chessPosition);
            Console.WriteLine(chessPosition.toPosition());
        }
    }
}
