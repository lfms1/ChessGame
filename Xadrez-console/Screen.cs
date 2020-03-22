using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int l = 0; l < board.Lines; l++)
            {
                for (int c = 0; c < board.Columns; c++)
                {
                    if (board.Piece(l, c) != null)
                    {
                        Console.Write(board.Piece(l, c) + " ");
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
