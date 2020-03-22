using System;
using board;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8,8);
            Screen.printBoard(board);
            Console.ReadLine();
        }
    }
}
