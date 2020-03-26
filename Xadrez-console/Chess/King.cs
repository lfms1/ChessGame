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
        public ChessMatch ChessMatch { get; set; }
        public King(Board board, Color color, ChessMatch chessMatch)
            : base(board, color)
        {
            ChessMatch = chessMatch;
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

        // Help Method for Testing the Tower for Castling
        private bool testTowerCastling(Position position) 
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Tower && piece.Color == Color && piece.MovementQuantity == 0;  
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

            //#SpecialMove Castling
            if (MovementQuantity == 0 && !ChessMatch.Check)
            {
                //#SpecialMove Short Castling
                Position positionTower1 = new Position(Position.Row, Position.Column + 3);
                if (testTowerCastling(positionTower1))
                {
                    Position position1 = new Position(Position.Row, Position.Column + 1);
                    Position position2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null)
                    {
                        array[Position.Row, Position.Column + 2] = true;
                    }
                }
                //#SpecialMove Long Castling
                Position positionTower2 = new Position(Position.Row, Position.Column - 4);
                if (testTowerCastling(positionTower2))
                {
                    Position position1 = new Position(Position.Row, Position.Column - 1);
                    Position position2 = new Position(Position.Row, Position.Column - 2);
                    Position position3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null && Board.Piece(position3) == null)
                    {
                        array[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return array;
        }
    }
}
