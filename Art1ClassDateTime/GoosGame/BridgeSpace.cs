using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class BridgeSpace : ISpace
    {
        public BridgeSpace(Shape backgroundShape)
        {
           BackgroundShape = backgroundShape;
        }

        public int Index { get; set; } = 6;
        public string Name { get; set; } = "Bridge";
        public SpaceTypes Type { get; set; } = SpaceTypes.BridgeSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.GoTo12 ;
    }
}
