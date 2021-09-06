using chess_console.board;

namespace chess_console.chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool EnemyExist(Position pawnPosition)
        {
            Piece piece = board.Piece(pawnPosition);
            return piece != null && piece.color != color;
        }

        private bool Free(Position pawnPosition)
        {
            return board.Piece(pawnPosition) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] positionsMoves = new bool[board.lines, board.columns];

            Position pawnPosition = new Position(0, 0);

            if(color == Color.White)
            {
                pawnPosition.setValues(position.line - 1, position.column);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line - 2, position.column);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line - 1, position.column - 1);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line - 1, position.column + 1);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;
            }
            else
            {
                pawnPosition.setValues(position.line + 1, position.column);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line + 2, position.column);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line + 1, position.column - 1);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line + 1, position.column + 1);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;
            }

            return positionsMoves;
        }
    }
}
