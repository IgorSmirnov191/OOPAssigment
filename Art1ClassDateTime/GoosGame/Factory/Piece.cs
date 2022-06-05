using System;

namespace GooseGame
{
    public class Piece : IPiece
    {
        public Piece(ConsoleColor colour, Shape pieceShape, Player piecePlayer, int leftRollsToMiss, bool turnOfUntilAnother, ISpace pieceCurrentSpace)
        {
            Colour = colour;
            PieceShape = pieceShape;
            PiecePlayer = piecePlayer;
            LeftRollsToMiss = leftRollsToMiss;
            TurnOffUntilAnother = turnOfUntilAnother;
            PieceCurrentSpace = pieceCurrentSpace;
        }

        public Piece(Player piecePlayer)
        {
            PiecePlayer = piecePlayer;
        }

        public Piece() { }
        public ConsoleColor Colour { get; set; }
        public IShape PieceShape { get; set; }
        public Player PiecePlayer { get; set; }
        public int LeftRollsToMiss { get; set; } = 0;

        public bool TurnOffUntilAnother { get; set; } = false;
        public ISpace PieceCurrentSpace { get; set; } = new StartSpace(1);

        public void LocateTo(ISpace space)
        {
            PieceCurrentSpace = space;
        }
    }
}