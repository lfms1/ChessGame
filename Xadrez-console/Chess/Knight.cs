using board;
using color;
using piece;
using position;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color)
            : base(board, color)
        {

        }
        public override string ToString()
        {
            return "H";
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

            //Position NWW
            position.SetValues(Position.Row - 1, Position.Column -2);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position NWN
            position.SetValues(Position.Row - 2, Position.Column -1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position NEN
            position.SetValues(Position.Row -2, Position.Column + 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position NEE
            position.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position SEE
            position.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position SES
            position.SetValues(Position.Row + 2, Position.Column +1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position SWS
            position.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }
            //Position SWW
            position.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && canMove(position))
            {
                array[position.Row, position.Column] = true;
            }

            return array;
        }
    }
}
