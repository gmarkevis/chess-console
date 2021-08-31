using chess_console.board;

namespace chess_console.chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
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

            Position rookPosition = new Position(0, 0);

            // Up
            rookPosition.setValues(position.line - 1, position.column);
            while (board.ValidPosition(rookPosition) && canMove(rookPosition))
            {
                positionsMoves[rookPosition.line, rookPosition.column] = true;

                if (board.Piece(rookPosition) != null && board.Piece(rookPosition).color != color)
                    break;

                rookPosition.line -= 1;
            }

            // Down
            rookPosition.setValues(position.line + 1, position.column);
            while (board.ValidPosition(rookPosition) && canMove(rookPosition))
            {
                positionsMoves[rookPosition.line, rookPosition.column] = true;

                if (board.Piece(rookPosition) != null && board.Piece(rookPosition).color != color)
                    break;

                rookPosition.line += 1;
            }

            // Right
            rookPosition.setValues(position.line, position.column + 1);
            while (board.ValidPosition(rookPosition) && canMove(rookPosition))
            {
                positionsMoves[rookPosition.line, rookPosition.column] = true;

                if (board.Piece(rookPosition) != null && board.Piece(rookPosition).color != color)
                    break;

                rookPosition.column += 1;
            }

            // Left
            rookPosition.setValues(position.line, position.column - 1);
            while (board.ValidPosition(rookPosition) && canMove(rookPosition))
            {
                positionsMoves[rookPosition.line, rookPosition.column] = true;

                if (board.Piece(rookPosition) != null && board.Piece(rookPosition).color != color)
                    break;

                rookPosition.column -= 1;
            }

            return positionsMoves;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
