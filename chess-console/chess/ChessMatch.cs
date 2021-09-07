using chess_console.board;
using System;
using System.Collections.Generic;

namespace chess_console.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int shift { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finishedMatch { get; set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPiecesInMatch;
        public bool check { get; private set; }
        public Piece vulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            shift = 1;
            this.currentPlayer = Color.White;
            finishedMatch = false;
            pieces = new HashSet<Piece>();
            capturedPiecesInMatch = new HashSet<Piece>();
            check = false;
            vulnerableEnPassant = null;
            PlacePiecesChessMatch();
        }

        public Piece PerformMovement(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementAmountMoves();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PlacePiece(piece, destiny);

            if (capturedPiece != null)
                capturedPiecesInMatch.Add(capturedPiece);

            // #specialmove short castling
            if(piece is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestiny = new Position(origin.line, origin.column + 1);
                Piece rook = board.RemovePiece(rookOrigin);
                rook.IncrementAmountMoves();
                board.PlacePiece(rook, rookDestiny);
            }

            // #specialmove long castling
            if (piece is King && destiny.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestiny = new Position(origin.line, origin.column - 1);
                Piece rook = board.RemovePiece(rookOrigin);
                rook.IncrementAmountMoves();
                board.PlacePiece(rook, rookDestiny);
            }

            // #specialmove En Passant
            if(piece is Pawn)
            {
                if(origin.column != destiny.column && capturedPiece == null)
                {
                    Position pawnPosition;
                    if (piece.color == Color.White)
                        pawnPosition = new Position(destiny.line + 1, destiny.column);
                    else
                        pawnPosition = new Position(destiny.line - 1, destiny.column);

                    capturedPiece = board.RemovePiece(pawnPosition);
                    capturedPiecesInMatch.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = board.RemovePiece(destiny);
            piece.DecrementAmountMoves();

            if (capturedPiece != null)
            {
                board.PlacePiece(capturedPiece, destiny);
                capturedPiecesInMatch.Remove(capturedPiece);
            }

            board.PlacePiece(piece, origin);

            // #specialmove short castling
            if (piece is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestiny = new Position(origin.line, origin.column + 1);
                Piece rook = board.RemovePiece(rookDestiny);
                rook.DecrementAmountMoves();
                board.PlacePiece(rook, rookOrigin);
            }

            // #specialmove long castling
            if (piece is King && destiny.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestiny = new Position(origin.line, origin.column - 1);
                Piece rook = board.RemovePiece(rookDestiny);
                rook.IncrementAmountMoves();
                board.PlacePiece(rook, rookOrigin);
            }

            // #specialmove En Passant
            if(piece is Pawn)
            {
                if(origin.column != destiny.column && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = board.RemovePiece(destiny);
                    Position pawnPosition;

                    if (piece.color == Color.White)
                        pawnPosition = new Position(3, destiny.column);
                    else
                        pawnPosition = new Position(4, destiny.column);

                    board.PlacePiece(pawn, pawnPosition);
                }
            }
        }

        public void MakeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = PerformMovement(origin, destiny);

            if (InCheckMate(currentPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            Piece piece = board.Piece(destiny);
            // #specialmove Promotion
            if(piece is Pawn)
            {
                if((piece.color == Color.White && destiny.line == 0) || (piece.color == Color.Black && destiny.line == 7))
                {
                    piece = board.RemovePiece(destiny);
                    pieces.Remove(piece);
                    Piece queen = new Queen(board, piece.color);
                    board.PlacePiece(queen, destiny);
                    pieces.Add(queen);
                }
            }

            if (InCheckMate(OpposingColor(currentPlayer)))
                check = true;
            else
                check = false;

            if (CheckMateTest(OpposingColor(currentPlayer)))
            {
                finishedMatch = true;
            }
            else
            {
                shift++;
                ChangePlayer();
            }

            
            // #specialmove En Passant
            if (piece is Pawn && (destiny.line == origin.line - 2 || destiny.line == origin.line + 2))
                vulnerableEnPassant = piece;
            else
                vulnerableEnPassant = null;
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
            if (!(board.Piece(origin).PossibleMove(destiny)))
                throw new BoardException("Invalid destiny position!");
        }

        public void ChangePlayer()
        {
            if (currentPlayer == Color.White)
                currentPlayer = Color.Black;
            else
                currentPlayer = Color.White;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> capturedPiecesByColor = new HashSet<Piece>();

            foreach (Piece piece in capturedPiecesInMatch)
            {
                if (piece.color == color)
                    capturedPiecesByColor.Add(piece);
            }

            return capturedPiecesByColor;
        }

        public HashSet<Piece> PiecesInMatch(Color color)
        {
            HashSet<Piece> piecesInMatch = new HashSet<Piece>();

            foreach (Piece piece in pieces)
            {
                if (piece.color == color)
                    piecesInMatch.Add(piece);
            }

            piecesInMatch.ExceptWith(CapturedPieces(color));

            return piecesInMatch;
        }

        private Color OpposingColor(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInMatch(color))
            {
                if (piece is King)
                    return piece;
            }

            return null;
        }

        public bool InCheckMate(Color color)
        {
            Piece king = King(color);

            if (king == null)
                throw new BoardException("There is no " + color + " king on the board!");

            foreach (Piece piece in PiecesInMatch(OpposingColor(color)))
            {
                bool[,] possibleMoves = piece.PossibleMoves();

                if (possibleMoves[king.position.line, king.position.column])
                    return true;
            }
            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if (!InCheckMate(color))
                return false;

            foreach (Piece piece in PiecesInMatch(color))
            {
                bool[,] possibleMoves = piece.PossibleMoves();

                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (possibleMoves[i, j])
                        {
                            Position origin = piece.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = PerformMovement(origin, destiny);
                            bool currentKingCheck = InCheckMate(color);
                            UndoMovement(origin, destiny, capturedPiece);

                            if (!currentKingCheck)
                                return false;
                        }
                    }
                }
            }

            return true;
        }

        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            board.PlacePiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void PlacePiecesChessMatch()
        {
            PlaceNewPiece('a', 1, new Rook(board, Color.White));
            PlaceNewPiece('b', 1, new Horse(board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(board, Color.White));
            PlaceNewPiece('d', 1, new Queen(board, Color.White));
            PlaceNewPiece('e', 1, new King(board, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(board, Color.White));
            PlaceNewPiece('g', 1, new Horse(board, Color.White));
            PlaceNewPiece('h', 1, new Rook(board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('b', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('c', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('d', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('e', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('f', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('g', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('h', 2, new Pawn(board, Color.White, this));

            PlaceNewPiece('a', 8, new Rook(board, Color.Black));
            PlaceNewPiece('b', 8, new Horse(board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(board, Color.Black));
            PlaceNewPiece('e', 8, new King(board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('g', 8, new Horse(board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('b', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('c', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('d', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('e', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('f', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('g', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('h', 7, new Pawn(board, Color.Black, this));
        }
    }
}
