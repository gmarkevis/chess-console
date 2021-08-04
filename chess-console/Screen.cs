using chess_console.board;

namespace chess_console
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                        System.Console.Write("- ");
                    else
                        System.Console.WriteLine(board.Piece(i, j) + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}
