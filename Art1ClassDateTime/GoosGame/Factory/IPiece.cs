using System;

namespace GooseGame
{
    public interface IPiece
    {
        ConsoleColor Colour { get; set; }
        IShape PieceShape { get; set; }
        ISpace PieceCurrentSpace { get; set; }
        Player PiecePlayer { get; set; }
        int LeftRollsToMiss { get; set; }
        bool TurnOffUntilAnother { get; set; }

        void LocateTo(ISpace space);
    }
}