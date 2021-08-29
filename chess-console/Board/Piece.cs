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

        public abstract bool[,] PossibleMoves();
    }
}
