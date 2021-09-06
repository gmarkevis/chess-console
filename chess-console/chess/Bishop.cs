using chess_console.board;

namespace chess_console.chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        private bool canMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] positionsMoves = new bool[board.lines, board.columns];

            Position bishopPosition = new Position(0, 0);

            // Northwest
            bishopPosition.setValues(position.line - 1, position.column -1);
            while (board.ValidPosition(bishopPosition) && canMove(bishopPosition))
            {
                positionsMoves[bishopPosition.line, bishopPosition.column] = true;

                if (board.Piece(bishopPosition) != null && board.Piece(bishopPosition).color != color)
                    break;

                bishopPosition.setValues(bishopPosition.line - 1, bishopPosition.column - 1);
            }

            // Northeast
            bishopPosition.setValues(position.line - 1, position.column + 1);
            while (board.ValidPosition(bishopPosition) && canMove(bishopPosition))
            {
                positionsMoves[bishopPosition.line, bishopPosition.column] = true;

                if (board.Piece(bishopPosition) != null && board.Piece(bishopPosition).color != color)
                    break;

                bishopPosition.setValues(bishopPosition.line - 1, bishopPosition.column + 1);
            }

            // Southeast
            bishopPosition.setValues(position.line + 1, position.column + 1);
            while (board.ValidPosition(bishopPosition) && canMove(bishopPosition))
            {
                positionsMoves[bishopPosition.line, bishopPosition.column] = true;

                if (board.Piece(bishopPosition) != null && board.Piece(bishopPosition).color != color)
                    break;

                bishopPosition.setValues(bishopPosition.line + 1, bishopPosition.column + 1);
            }

            // Southwest
            bishopPosition.setValues(position.line + 1, position.column - 1);
            while (board.ValidPosition(bishopPosition) && canMove(bishopPosition))
            {
                positionsMoves[bishopPosition.line, bishopPosition.column] = true;

                if (board.Piece(bishopPosition) != null && board.Piece(bishopPosition).color != color)
                    break;

                bishopPosition.setValues(bishopPosition.line + 1, bishopPosition.column - 1);
            }

            return positionsMoves;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
