using board;
using color;
using piece;
using position;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Chess
{
    class Bishop : Piece
    {   
        public Bishop(Board board, Color color)
            : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        // Help Method for PossibleMovements Method
        private bool canMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }
      
        public override bool[,] PossibleMovements()
        {
            bool[,] array = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //Position NE
            position.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row--;
                position.Column++;
            }

            //Position SE
            position.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row++;
                position.Column++;
            }

            //Position SW
            position.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row++;
                position.Column--;
            }

            //Position NW
            position.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row--;
                position.Column--;
            }

            return array;
        }
    }
}
