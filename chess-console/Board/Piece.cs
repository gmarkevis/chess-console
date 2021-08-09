namespace chess_console.board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int amountMoves{ get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            amountMoves = 0;
        }

        public void incrementAmountMoves()
        {
            amountMoves++;
        }
    }
}
