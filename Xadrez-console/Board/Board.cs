using System;
using System.Collections.Generic;
using System.Text;
using piece;
using position;

namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces;
        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int line, int column) 
        {
            return Pieces[line, column];
        }

        public void PlacePiece(Piece piece, Position position) {

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
