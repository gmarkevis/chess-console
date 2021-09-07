using chess_console.board;

namespace chess_console.chess
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

                // #specialmove En Passant
                if(position.line == 3)
                {
                    Position pawnLeft = new Position(position.line, position.column - 1);
                    if(board.ValidPosition(pawnLeft) && HaveEnemy(pawnLeft) && board.Piece(pawnLeft) == match.vulnerableEnPassant)                    
                        positionsMoves[pawnLeft.line - 1, pawnLeft.column] = true;

                    Position pawnRight = new Position(position.line, position.column + 1);
                    if (board.ValidPosition(pawnRight) && HaveEnemy(pawnRight) && board.Piece(pawnRight) == match.vulnerableEnPassant)
                        positionsMoves[pawnRight.line - 1, pawnRight.column] = true;
                }
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

                // #specialmove En Passant
                if (position.line == 4)
                {
                    Position pawnLeft = new Position(position.line, position.column - 1);
                    if (board.ValidPosition(pawnLeft) && HaveEnemy(pawnLeft) && board.Piece(pawnLeft) == match.vulnerableEnPassant)
                        positionsMoves[pawnLeft.line + 1, pawnLeft.column] = true;

                    Position pawnRight = new Position(position.line, position.column + 1);
                    if (board.ValidPosition(pawnRight) && HaveEnemy(pawnRight) && board.Piece(pawnRight) == match.vulnerableEnPassant)
                        positionsMoves[pawnRight.line + 1, pawnRight.column] = true;
                }
            }

            return positionsMoves;
        }
    }
}
