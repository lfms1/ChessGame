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
            ChessPosition chessPosition = new ChessPosition('c', 7);

            Console.WriteLine(chessPosition.ConvertToPosition());
            Console.WriteLine(chessPosition);
        }
    }
}
