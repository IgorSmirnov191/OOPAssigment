using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class PrisonSpace : ISpace
    {
        public PrisonSpace(Shape backgroundShape)
        {
            BackgroundShape = backgroundShape;
        }
        public int Index { get; set; } = 52;
        public string Name { get; set; } = "Prison";
        public SpaceTypes Type { get; set; } = SpaceTypes.PrisonSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.SkipThreeTurns;
    }
}
