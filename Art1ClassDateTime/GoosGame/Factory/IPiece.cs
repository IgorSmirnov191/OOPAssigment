using System;

namespace GooseGame
{
    public interface IPiece
    {
        ConsoleColor Colour { get; set; }
        Shape PieceShape { get; set; }
    }
}