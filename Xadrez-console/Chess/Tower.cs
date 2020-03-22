using board;
using color;
using piece;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color)
            : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
