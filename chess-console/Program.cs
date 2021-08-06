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
                Board board = new Board(8, 8);

                board.placePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.placePiece(new Rook(board, Color.Black), new Position(1, 9));
                board.placePiece(new King(board, Color.Black), new Position(2, 4));

                Screen.printBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
