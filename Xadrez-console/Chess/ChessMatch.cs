using board;
using color;
using exceptions;
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

        public void ExecutePlay(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            changePlayer();
        }

        public void ValidOriginPosition(Position position) 
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in that position");
            }
            if (!Board.Piece(position).existPossibleMovements())
            {
                throw new BoardException("There is no possible moves for this piece");
            }
            if (Board.Piece(position).Color != ActualPlayer)
            {
                throw new BoardException("That piece isn't yours");
            }
        }

        public void ValidDestinyPosition(Position originPosition, Position destinyPosition)
        {
            if (!Board.Piece(originPosition).canMoveTo(destinyPosition))
            {
                throw new BoardException("Invalid target position");
            }
        }

        private void changePlayer() 
        { 
            if(ActualPlayer == Color.Black)
            {
                ActualPlayer = Color.White;
            }
            else 
            {
                ActualPlayer = Color.Black;
            }
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
