using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class InnSpace : ISpace
    {
        public InnSpace(Shape backgroundShape)
        {
          BackgroundShape = backgroundShape;
        }

        public int Index { get; set; } = 19;
        public string Name { get; set; } = "Inn";
        public SpaceTypes Type { get; set; }
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } =  Rules.SkipOneTurn;
    }
}
