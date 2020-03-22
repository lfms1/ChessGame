using System;
using board;
using color;
using piece;
using position;
using Xadrez_console.Chess;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8,8);
            board.PlacePiece(new Tower(board, Color.Black), new Position(0, 0));
            board.PlacePiece(new King(board, Color.Black), new Position(1, 3));

            Screen.printBoard(board);
            Console.ReadLine();
        }
    }
}
