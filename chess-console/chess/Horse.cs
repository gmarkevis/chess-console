using chess_console.board;

namespace chess_console.chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "H";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] positionsMoves = new bool[board.lines, board.columns];

            Position horsePosition = new Position(0, 0);

            horsePosition.setValues(position.line - 1, position.column - 2);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line - 2, position.column - 1);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line - 2, position.column + 1);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line - 1, position.column + 2);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line + 1, position.column + 2);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line + 2, position.column + 1);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line + 2, position.column - 1);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            horsePosition.setValues(position.line + 1, position.column - 2);
            if (board.ValidPosition(horsePosition) && canMove(horsePosition))
                positionsMoves[horsePosition.line, horsePosition.column] = true;

            return positionsMoves;
        }
    }
}
