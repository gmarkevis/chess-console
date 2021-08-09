namespace chess_console.board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            this.Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            validatePosition(position);
            return Pieces[position.Line, position.Column];
        }

        public bool pieceExists(Position position)
        {
            return Piece(position) != null;
        }

        public void placePiece(Piece piece, Position position)
        {
            if (pieceExists(position))
                throw new BoardException("There is already a piece in that position!");

            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece removePiece(Position position)
        {
            if (Piece(position) == null)
                return null;

            Piece currentPiece = Piece(position);
            currentPiece.Position = null;
            Pieces[position.Line, position.Column] = null;

            return currentPiece;
        }

        public bool validPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
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
