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

        private bool HaveEnemy(Position pawnPosition)
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

            if (color == Color.White) {

                pawnPosition.setValues(position.line - 1, position.column);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition)) 
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line - 2, position.column);
                Position pawnPosition2 = new Position(position.line - 1, position.column);
                if (board.ValidPosition(pawnPosition2) && Free(pawnPosition2) && board.ValidPosition(pawnPosition) && Free(pawnPosition) && amountMoves == 0)
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line - 1, position.column - 1);
                if (board.ValidPosition(pawnPosition) && HaveEnemy(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line - 1, position.column + 1);
                if (board.ValidPosition(pawnPosition) && HaveEnemy(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;
            }
            else {
                pawnPosition.setValues(position.line + 1, position.column);
                if (board.ValidPosition(pawnPosition) && Free(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line + 2, position.column);
                Position pawnPosition2 = new Position(position.line + 1, position.column);
                if (board.ValidPosition(pawnPosition2) && Free(pawnPosition2) && board.ValidPosition(pawnPosition) && Free(pawnPosition) && amountMoves == 0)
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line + 1, position.column - 1);
                if (board.ValidPosition(pawnPosition) && HaveEnemy(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;

                pawnPosition.setValues(position.line + 1, position.column + 1);
                if (board.ValidPosition(pawnPosition) && HaveEnemy(pawnPosition))
                    positionsMoves[pawnPosition.line, pawnPosition.column] = true;
            }

            return positionsMoves;
        }
    }
}
