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
        public ChessMatch ChessMatch { get; private set; }
        public Pawn(Board board, Color color, ChessMatch chessMatch)
            : base(board, color)
        {
            ChessMatch = chessMatch;
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

                position.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && existEnemy(position))
                {
                    array[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && existEnemy(position))
                {
                    array[position.Row, position.Column] = true;
                }

                //Special Move en Passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && existEnemy(left) && Board.Piece(left) == ChessMatch.VulnerableEnPassant)
                    {
                        array[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && existEnemy(right) && Board.Piece(right) == ChessMatch.VulnerableEnPassant)
                    {
                        array[right.Row - 1, right.Column] = true;
                    }
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

                //Special Move en Passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && existEnemy(left) && Board.Piece(left) == ChessMatch.VulnerableEnPassant)
                    {
                        array[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && existEnemy(right) && Board.Piece(right) == ChessMatch.VulnerableEnPassant)
                    {
                        array[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return array;
        }


    }
}
