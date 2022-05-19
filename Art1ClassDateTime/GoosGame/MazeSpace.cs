using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class MazeSpace : ISpace
    {
        public MazeSpace(Shape backgroundShape)
        {
            BackgroundShape = backgroundShape;
        }
        public int Index { get; set; } = 42;
        public string Name { get; set; } = "Maze";
        public SpaceTypes Type { get; set; } = SpaceTypes.MazeSpace;
        public Shape BackgroundShape { get; set; }
        public Rules Action { get; set; } = Rules.GoTo39;
    }
}
