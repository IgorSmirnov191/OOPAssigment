using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class StaticSpace : ISpace
    {
        public StaticSpace(int index, Shape backgroundShape)
        {
            Index = index;
            BackgroundShape = backgroundShape;
            Name = index.ToString();
           
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.None;
        public SpaceTypes Type { get; set; } = SpaceTypes.StaticSpace;

    }
}
