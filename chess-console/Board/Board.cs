﻿namespace chess_console.board
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

        public void placePiece(Piece piece, Position position)
        {
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
