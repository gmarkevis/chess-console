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
            ValidatePosition(position);
            return pieces[position.line, position.column];
        }

        public bool PieceExists(Position position)
        {
            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (PieceExists(position))
                throw new BoardException("There is already a piece in that position!");

            pieces[position.line, position.column] = piece;
            piece.position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
                return null;

            Piece currentPiece = Piece(position);
            currentPiece.position = null;
            pieces[position.line, position.column] = null;

            return currentPiece;
        }

        public bool ValidPosition(Position position)
        {
            if (position.line < 0 || position.line >= lines || position.column < 0 || position.column >= columns)
                return false;

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
                throw new BoardException("Invalid position!");
        }
    }
}
