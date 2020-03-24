using System;
using System.Collections.Generic;
using System.Text;
using piece;
using position;
using exceptions;

namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces;
        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(Position position) 
        {
            return Pieces[position.Row, position.Column];
        }

        public Piece Piece(int line, int column) 
        {
            return Pieces[line, column];
        }

        public bool hasPiece(Position position) 
        {
            ValidationPosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position) {
            if (hasPiece(position))
            {
                throw new BoardException("Has already one piece in that position");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;

        }

        public Piece RemovePiece(Position position) 
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece nullPiece = Piece(position);
            nullPiece.Position = null;
            Pieces[position.Row, position.Column] = null;
            return nullPiece; 
        }

        public bool ValidPosition(Position position) 
        {
            if (position.Row >= Rows || position.Column >= Columns || position.Column < 0 || position.Row < 0)
            {
                return false;
            }
            return true;
        }

        public void ValidationPosition(Position position) 
        {
            if (!ValidPosition(position)) throw new BoardException("This is not a valid positon");
           
        }
    }
}
