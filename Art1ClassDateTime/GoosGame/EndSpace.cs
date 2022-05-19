using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class EndSpace : ISpace
    {
        public EndSpace(Shape backgroundShape)
        {
            BackgroundShape = backgroundShape;
        }
        public int Index { get; set; } = 63;
        public string Name { get; set; } = "Game Over";
        public SpaceTypes Type { get; set; } = SpaceTypes.EndSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.WinnerStopGame;
    }
}
