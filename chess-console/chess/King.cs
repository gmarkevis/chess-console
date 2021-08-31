using chess_console.board;

namespace chess_console.chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
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

            return positionsMoves;
        }
    }
}
