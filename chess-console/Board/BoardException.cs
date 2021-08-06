using System;

namespace chess_console.board
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}
