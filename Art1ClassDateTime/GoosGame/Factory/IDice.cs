using System;

namespace GooseGame
{
    public interface IDice
    {
        Random RandomRoller { get; set; }

        void Roll();
    }
}