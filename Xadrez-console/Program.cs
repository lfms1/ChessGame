using System;
using color;
using piece;
using position;
using board;
using Xadrez_console.Chess;
using exceptions;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();
                while (!chessMatch.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(chessMatch);

                        Console.WriteLine();
                        Console.Write("Origin:");
                        Position originPosition = Screen.ReadChessPosition().ConvertToPosition();
                        chessMatch.ValidOriginPosition(originPosition);

                        bool[,] possiblePositions = chessMatch.Board.Piece(originPosition).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(chessMatch.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny:");
                        Position destinyPosition = Screen.ReadChessPosition().ConvertToPosition();
                        chessMatch.ValidDestinyPosition(originPosition, destinyPosition);

                        chessMatch.ExecutePlay(originPosition, destinyPosition);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
