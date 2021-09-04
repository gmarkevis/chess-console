namespace chess_console.board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int amountMoves{ get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            position = null;
            this.color = color;
            this.board = board;
            amountMoves = 0;
        }

        public void IncrementAmountMoves()
        {
            amountMoves++;
        }

        public void DecrementAmountMoves()
        {
            amountMoves--;
        }

        public bool PossibleMovesExists()
        {
            bool[,] possibleMoves = PossibleMoves();
            for(int i = 0; i < board.lines; i++)
            {
                for(int j = 0; j < board.columns; j++)
                {
                    if (possibleMoves[i, j])
                        return true;
                }
            }

            return false;
        }

        public bool PossibleMove(Position piecePosition)
        {
            return PossibleMoves()[piecePosition.line, piecePosition.column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
