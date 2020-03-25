using board;
using color;
using piece;
using position;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color)
            : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool existEnemy(Position position) 
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color; 
        }

        private bool isFree(Position position) 
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] array = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(position) && isFree(position))
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(position) && isFree(position) && MovementQuantity == 0)
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column -1);
                if (Board.ValidPosition(position) && existEnemy(position))
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && existEnemy(position))
                {
                    array[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(position) && isFree(position))
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(position) && isFree(position) && MovementQuantity == 0)
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && existEnemy(position))
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && existEnemy(position))
                {
                    array[position.Row, position.Column] = true;
                }
            }

            return array;
        }


    }
}
