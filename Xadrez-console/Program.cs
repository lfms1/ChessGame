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
                Board board = new Board(8, 8);
                board.PlacePiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PlacePiece(new King(board, Color.Black), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(0, 4));
                

                Screen.printBoard(board);
                Console.ReadLine();
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
            
        }
    }
}
