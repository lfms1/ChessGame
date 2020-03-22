using board;
using color;
using piece;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Chess
{
    class King : Piece
    {
        public King(Board board, Color color) 
            : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
