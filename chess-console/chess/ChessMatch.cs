using chess_console.board;
using System;

namespace chess_console.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int shift;
        private Color currentPlayer;
        public bool finishedMatch { get; set; }

        public ChessMatch()
        {
            board = new Board(8,8);
            shift = 1;
            this.currentPlayer = Color.White;
            finishedMatch = false;
            placePiecesChessMatch();
        }


        public void performMovement(Position origin, Position destiny)
        {
            Piece piece = board.removePiece(origin);
            piece.IncrementAmountMoves();
            Piece capturedPiece = board.removePiece(destiny);
            board.placePiece(piece, destiny);
        }
        private void placePiecesChessMatch()
        {
            board.placePiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.placePiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.placePiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
