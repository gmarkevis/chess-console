using System;
using chess_console.board;
using chess_console.chess;

namespace chess_console
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition readChessPosition()
        {
            string typedPosition = Console.ReadLine();
            char column = typedPosition[0];
            int line = int.Parse(typedPosition[1] + "");

            return new ChessPosition(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = currentColor;
            }

        }
    }
}
