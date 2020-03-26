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
        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            AddingPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovementQuantity();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PlacePiece(piece, destiny);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            // #SpecialMove Short Castling
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position originTower = new Position(origin.Row, origin.Column + 3);
                Position destinyTower = new Position(origin.Row, origin.Column + 1);
                Piece tower = Board.RemovePiece(originTower);
                tower.IncrementMovementQuantity();
                Board.PlacePiece(tower, destinyTower);
            }

            // #SpecialMove Long Castling
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position originTower = new Position(origin.Row, origin.Column - 4);
                Position destinyTower = new Position(origin.Row, origin.Column - 1);
                Piece tower = Board.RemovePiece(originTower);
                tower.IncrementMovementQuantity();
                Board.PlacePiece(tower, destinyTower);
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecreaseMovementQuantity();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }

            Board.PlacePiece(piece, origin);

            // #SpecialMove Short Castling
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position originTower = new Position(origin.Row, origin.Column + 3);
                Position destinyTower = new Position(origin.Row, origin.Column + 1);
                Piece tower = Board.RemovePiece(destinyTower);
                tower.DecreaseMovementQuantity();
                Board.PlacePiece(tower, originTower);
            }

            // #SpecialMove Long Castling
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position originTower = new Position(origin.Row, origin.Column - 4);
                Position destinyTower = new Position(origin.Row, origin.Column - 1);
                Piece tower = Board.RemovePiece(destinyTower);
                tower.DecreaseMovementQuantity();
                Board.PlacePiece(tower, originTower);
            }
        }

        public void ExecutePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny);
            if (IsInCheck(ActualPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }
            if (IsInCheck(enemyColor(ActualPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (TestCheckmate(enemyColor(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                changePlayer();
            }
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
            if (ActualPlayer == Color.Black)
            {
                ActualPlayer = Color.White;
            }
            else
            {
                ActualPlayer = Color.Black;
            }
        }

        public HashSet<Piece> getCapturedPiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            return aux;
        }

        public HashSet<Piece> getInGamePiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            aux.ExceptWith(CapturedPieces);
            return aux;
        }

        private Color enemyColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece getKingByColor(Color color)
        {
            foreach (Piece piece in getInGamePiecesByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = getKingByColor(color);
            if (king == null)
            {
                throw new BoardException("There is no " + color + "king");
            }
            foreach (Piece piece in getInGamePiecesByColor(enemyColor(color)))
            {
                bool[,] array = piece.PossibleMovements();
                if (array[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool TestCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece piece in getInGamePiecesByColor(color))
            {
                bool[,] array = piece.PossibleMovements();
                for (int r = 0; r < Board.Rows; r++)
                {
                    for (int c = 0; c < Board.Columns; c++)
                    {
                        if (array[r, c])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(r, c);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ConvertToPosition());
            Pieces.Add(piece);
        }

        private void AddingPieces()
        {
            PlaceNewPiece('a', 1, new Tower(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Tower(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));

            PlaceNewPiece('a', 8, new Tower(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Tower(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black));
        }
    }
}
