using System;
using chess_console.board;
using chess_console.chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.finishedMatch)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();

                        Console.Write("Origin position: ");
                        Position origin = Screen.ReadChessPosition().toPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possibleMoves = match.board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.board, possibleMoves);

                        Console.WriteLine();
                        Console.Write("Destiny position: ");
                        Position destiny = Screen.ReadChessPosition().toPosition();
                        match.ValidateDestinyPosition(origin, destiny);

                        match.MakeMove(origin, destiny);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.PrintMatch(match);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
