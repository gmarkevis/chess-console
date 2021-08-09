using chess_console.board;
using System;

namespace chess_console.chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Shift;
        private Color currentPlayer;
        public bool finishedMatch { get; set; }

        public ChessMatch()
        {
            Board = new Board(8,8);
            Shift = 1;
            this.currentPlayer = Color.White;
            finishedMatch = false;
            placePiecesChessMatch();
        }


        public void performMovement(Position origin, Position destiny)
        {
            Piece piece = Board.removePiece(origin);
            piece.incrementAmountMoves();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.placePiece(piece, destiny);
        }
        private void placePiecesChessMatch()
        {
            Board.placePiece(new Rook(Board, Color.White), new ChessPosition('c', 1).toPosition());
            Board.placePiece(new Rook(Board, Color.White), new ChessPosition('c', 2).toPosition());
            Board.placePiece(new Rook(Board, Color.White), new ChessPosition('d', 2).toPosition());
            Board.placePiece(new Rook(Board, Color.White), new ChessPosition('e', 2).toPosition());
            Board.placePiece(new Rook(Board, Color.White), new ChessPosition('e', 1).toPosition());
            Board.placePiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());

            Board.placePiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).toPosition());
            Board.placePiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            Board.placePiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).toPosition());
            Board.placePiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).toPosition());
            Board.placePiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            Board.placePiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
