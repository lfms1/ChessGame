using board;
using color;
using position;
using System;
using System.Collections.Generic;
using System.Text;

namespace piece
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; } //Só pode ser alterada por ela própria e por subclasses
        public int MovementQuantity { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MovementQuantity = 0;
        }


    }
}
