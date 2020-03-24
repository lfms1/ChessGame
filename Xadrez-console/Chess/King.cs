using board;
using color;
using piece;
using position;
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

            //Position N
            position.SetValues(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position NE
            position.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position E
            position.SetValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position SE
            position.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position S
            position.SetValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position SW
            position.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position W
            position.SetValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position NW
            position.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }

            return array;
        }
    }
}
