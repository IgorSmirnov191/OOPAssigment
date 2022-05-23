using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public class StartSpace : StaticSpace
    {
        public StartSpace(int index, Shape backgroundShape) : base(index, backgroundShape)
        {
            
            Name = "Start";
        }
    }
}
