using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class DeathSpace : ISpace
    {
        public DeathSpace(Shape backgroundShape)
        {
            BackgroundShape = backgroundShape;
        }
        public int Index { get; set; } = 58;
        public string Name { get; set; } = "Death";
        public SpaceTypes Type { get; set; } = SpaceTypes.DeathSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.GoToStart;
    }
}
