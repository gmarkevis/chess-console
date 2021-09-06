using chess_console.board;

namespace chess_console.chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] positionsMoves = new bool[board.lines, board.columns];

            Position queenPosition = new Position(0, 0);

            // Up
            queenPosition.setValues(position.line - 1, position.column);
            while(board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line - 1, queenPosition.column);
            }

            // Northeast
            queenPosition.setValues(position.line - 1, position.column + 1);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line - 1, queenPosition.column + 1);
            }

            // Right
            queenPosition.setValues(position.line, position.column + 1);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line, queenPosition.column + 1);
            }

            // Southeast
            queenPosition.setValues(position.line + 1, position.column + 1);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line + 1, queenPosition.column + 1);
            }

            // Down
            queenPosition.setValues(position.line + 1, position.column);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line + 1, queenPosition.column);
            }

            // Southwest
            queenPosition.setValues(position.line + 1, position.column - 1);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line + 1, queenPosition.column - 1);
            }

            // Left
            queenPosition.setValues(position.line, position.column - 1);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line, queenPosition.column - 1);
            }

            // Northwest
            queenPosition.setValues(position.line - 1, position.column - 1);
            while (board.ValidPosition(queenPosition) && canMove(queenPosition))
            {
                positionsMoves[queenPosition.line, queenPosition.column] = true;

                if (board.Piece(queenPosition) != null && board.Piece(queenPosition).color != color)
                    break;

                queenPosition.setValues(queenPosition.line - 1, queenPosition.column - 1);
            }

            return positionsMoves;
        }
    }
}
