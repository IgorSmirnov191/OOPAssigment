using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame
{
    public interface IDice
    {
        Random RandomRoller { get; set; }
        void Roll();

    }
}
