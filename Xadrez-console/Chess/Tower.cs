using board;
using color;
using piece;
using position;
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
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row--;
            }

            //Position S
            position.SetValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row++;
            }

            //Position E
            position.SetValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column++;
            }

            //Position W
            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column--;
            }

            return array;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
