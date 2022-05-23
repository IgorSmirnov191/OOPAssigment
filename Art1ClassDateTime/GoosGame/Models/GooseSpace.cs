using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class GooseSpace : ISpace
    {
        public GooseSpace(int index, Shape backgroundShape)
        {
            Index = index;
            BackgroundShape = backgroundShape;
        }

        public int Index { get; set; }
        public string Name { get; set; } = "Goose";
        public SpaceTypes Type { get; set; } = SpaceTypes.GooseSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.FlyWithGoos;
    }
}
