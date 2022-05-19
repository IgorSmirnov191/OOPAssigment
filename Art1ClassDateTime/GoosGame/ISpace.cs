using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public interface ISpace
    {
        int Index { get; set; }
        string Name { get; set; }
        SpaceTypes Type { get; set; }
        Shape BackgroundShape { get; set; }
        Rules Action { get; set; }

    }
}
