using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class WellSpace : ISpace
    {
        public  WellSpace(Shape backgroundShape)
        {
            BackgroundShape = backgroundShape;
        }
        public int Index { get; set; } = 31;
        public string Name { get; set; } = "Well";
        public SpaceTypes Type { get; set; } = SpaceTypes.WellSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } =  Rules.WaitUntilAnotherArrives;
    }
}
