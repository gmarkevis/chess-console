namespace chess_console.board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            this.pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            validatePosition(position);
            return pieces[position.line, position.column];
        }

        public bool pieceExists(Position position)
        {
            return Piece(position) != null;
        }

        public void placePiece(Piece piece, Position position)
        {
            if (pieceExists(position))
                throw new BoardException("There is already a piece in that position!");

            pieces[position.line, position.column] = piece;
            piece.position = position;
        }

        public Piece removePiece(Position position)
        {
            if (Piece(position) == null)
                return null;

            Piece currentPiece = Piece(position);
            currentPiece.position = null;
            pieces[position.line, position.column] = null;

            return currentPiece;
        }

        public bool validPosition(Position position)
        {
            if (position.line < 0 || position.line >= lines || position.column < 0 || position.column >= columns)
                return false;

            return true;
        }

        public void validatePosition(Position position)
        {
            if (!validPosition(position))
                throw new BoardException("Invalid position!");
        }
    }
}
