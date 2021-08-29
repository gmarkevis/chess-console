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
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.WriteLine();

                    Console.Write("Origin position: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possibleMoves = match.board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.printBoard(match.board, possibleMoves);

                    Console.WriteLine();
                    Console.Write("Destiny position: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.performMovement(origin, destiny);
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
