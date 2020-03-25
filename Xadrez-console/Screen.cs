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
        public static void PrintMatch(ChessMatch chessMatch) 
        {
            PrintBoard(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessMatch.Turn);
            if (!chessMatch.Finished)
            {
                Console.WriteLine("Player turn: " + chessMatch.ActualPlayer);
                if (chessMatch.Check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else 
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("The winner is "+ chessMatch.ActualPlayer);
            }
           
        }

        public static void PrintCapturedPieces(ChessMatch chessMatch) 
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            PrintCapturedPiecesByColor(chessMatch.getCapturedPiecesByColor(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCapturedPiecesByColor(chessMatch.getCapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = defaultColor;
            Console.WriteLine();
        }

        public static void PrintCapturedPiecesByColor(HashSet<Piece> pieces) 
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {

            for (int l = 0; l < board.Rows; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < board.Columns; c++)
                {
                    PrintPiece(board.Piece(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor customBackgorundColor = ConsoleColor.DarkGray;

            for (int l = 0; l < board.Rows; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < board.Columns; c++)
                {
                    if (possiblePositions[l, c] == true)
                    {
                        Console.BackgroundColor = customBackgorundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackgroundColor;
                    }
                    PrintPiece(board.Piece(l, c));
                    Console.BackgroundColor = originalBackgroundColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackgroundColor;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
