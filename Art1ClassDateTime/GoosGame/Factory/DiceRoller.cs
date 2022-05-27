using System;
using System.Collections.Generic;

namespace GooseGame
{
    public class DiceRoller : IDice
    {
        public DiceRoller(int dicecount)
        {
            DiceCount = dicecount;
            RandomRoller = new Random();
        }

        public int DiceCount { get; set; }

        public int DicesScore { get; private set; } = 0;

        public List<int> Scoores { get; set; } = new List<int>();

        public Random RandomRoller { get; set; }

        public void Roll()
        {
            DicesScore = 0;
            Scoores.Clear();
            for (int i = 0; i < DiceCount; i++)
            {
                int nextvalue = RandomRoller.Next(1, 7);
                Scoores.Add(nextvalue);
                DicesScore += nextvalue;
            }
        }
    }
}