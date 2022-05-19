using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public interface IPiece
    {
        ConsoleColor Colour { get; set; }
        Shape PieceShape { get; set; }
    }
}
