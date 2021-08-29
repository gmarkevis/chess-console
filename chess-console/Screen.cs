using System;
using chess_console.board;
using chess_console.chess;

namespace chess_console
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possibleMoves[i, j])
                        Console.BackgroundColor = newBackground;
                    else
                        Console.BackgroundColor = currentBackground;

                    printPiece(board.Piece(i, j));
                    Console.BackgroundColor = currentBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = currentBackground;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
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
                Console.Write(" ");
            }

        }
    }
}
