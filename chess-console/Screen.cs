using System;
using System.Collections.Generic;
using chess_console.board;
using chess_console.chess;

namespace chess_console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine("Shift: " + match.shift);

            if (!match.finishedMatch)
            {
                Console.WriteLine("Waiting for move: " + match.currentPlayer);
                if (match.check)
                    Console.WriteLine("CHECK!");
            }
            else
            {
                Console.WriteLine("CHECKMATE!!!");
                Console.WriteLine("Winner: " + match.currentPlayer);
            }
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = currentConsoleColor;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> pieces)
        {
            Console.Write("[");

            foreach (Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }

            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
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

                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = currentBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = currentBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string typedPosition = Console.ReadLine();
            char column = typedPosition[0];
            int line = int.Parse(typedPosition[1] + "");

            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
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
