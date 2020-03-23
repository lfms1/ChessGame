using board;
using color;
using piece;
using position;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            AddingPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny) 
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovementQuantity();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PlacePiece(piece, destiny);
        }

        private void AddingPieces() 
        {
            Board.PlacePiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ConvertToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('d', 1).ConvertToPosition());

            Board.PlacePiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ConvertToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ConvertToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8).ConvertToPosition());
        }
    }
}
