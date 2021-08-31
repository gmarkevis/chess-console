using chess_console.board;
using System;

namespace chess_console.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int shift { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finishedMatch { get; set; }

        public ChessMatch()
        {
            board = new Board(8,8);
            shift = 1;
            this.currentPlayer = Color.White;
            finishedMatch = false;
            PlacePiecesChessMatch();
        }

        public void PerformMovement(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementAmountMoves();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PlacePiece(piece, destiny);
        }

        public void MakeMove(Position origin, Position destiny)
        {
            PerformMovement(origin, destiny);
            shift++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position originPosition)
        {
            if (board.Piece(originPosition) == null)
                throw new BoardException("There is not piece in chosen origin position!");

            if (currentPlayer != board.Piece(originPosition).color)
                throw new BoardException("The origin piece is not yours!");

            if (!board.Piece(originPosition).PossibleMovesExists())
                throw new BoardException("There are no possible moves for the chosen origin piece!");
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!(board.Piece(origin).CanMoveTo(destiny)))
                throw new BoardException("Invalid destiny position!");
        }

        public void ChangePlayer()
        {
            if (currentPlayer == Color.White)
                currentPlayer = Color.Black;
            else
                currentPlayer = Color.White;
        }

        private void PlacePiecesChessMatch()
        {
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.PlacePiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.PlacePiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
