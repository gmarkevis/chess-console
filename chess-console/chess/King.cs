using chess_console.board;

namespace chess_console.chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        private bool TestCastlingRook(Position rookPosition)
        {
            Piece piece = board.Piece(rookPosition);
            return piece != null && piece is Rook && piece.color == color && piece.amountMoves == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] positionsMoves = new bool[board.lines, board.columns];

            Position kingPosition = new Position(0, 0);

            // Up
            kingPosition.setValues(position.line - 1, position.column);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Northeast
            kingPosition.setValues(position.line - 1, position.column + 1);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Right
            kingPosition.setValues(position.line, position.column + 1);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Southeast
            kingPosition.setValues(position.line + 1, position.column + 1);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Down
            kingPosition.setValues(position.line + 1, position.column);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Southwest
            kingPosition.setValues(position.line + 1, position.column -1);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Left
            kingPosition.setValues(position.line, position.column - 1);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // Northwest
            kingPosition.setValues(position.line - 1, position.column - 1);
            if (board.ValidPosition(kingPosition) && canMove(kingPosition))
                positionsMoves[kingPosition.line, kingPosition.column] = true;

            // #specialmove castling
            if(amountMoves == 0 && !match.check)
            {
                // #specialmove short castling
                Position rookPosition1 = new Position(position.line, position.column + 3);
                if (TestCastlingRook(rookPosition1))
                {
                    Position kingNextPosition1 = new Position(position.line, position.column + 1);
                    Position kingNextPosition2 = new Position(position.line, position.column + 2);

                    if (board.Piece(kingNextPosition1) == null && board.Piece(kingNextPosition2) == null)
                        positionsMoves[position.line, position.column + 2] = true;
                }

                // #specialmove long castling
                Position rookPosition2 = new Position(position.line, position.column - 4);
                if (TestCastlingRook(rookPosition2))
                {
                    Position kingNextPosition1 = new Position(position.line, position.column - 1);
                    Position kingNextPosition2 = new Position(position.line, position.column - 2);
                    Position kingNextPosition3 = new Position(position.line, position.column - 3);

                    if (board.Piece(kingNextPosition1) == null 
                        && board.Piece(kingNextPosition2) == null && board.Piece(kingNextPosition3) == null)
                        positionsMoves[position.line, position.column - 2] = true;
                }
            }

            return positionsMoves;
        }
    }
}
