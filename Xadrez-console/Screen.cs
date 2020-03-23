using board;
using color;
using piece;
using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_console.Chess;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {

            for (int l = 0; l < board.Lines; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < board.Columns; c++)
                {
                    if (board.Piece(l, c) != null)
                    {
                        PrintPiece(board.Piece(l, c));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static ChessPosition ReadChessPosition() 
        {
            string s = Console.ReadLine();

            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = defaultColor;
            }
        }
    }
}
