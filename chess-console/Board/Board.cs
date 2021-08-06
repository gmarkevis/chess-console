namespace chess_console.board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            this.pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            validatePosition(position);
            return pieces[position.Line, position.Column];
        }

        public bool pieceExists(Position position)
        {
            return Piece(position) != null;
        }

        public void placePiece(Piece piece, Position position)
        {
            if (pieceExists(position))
                throw new BoardException("There is already a piece in that position!");

            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
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
