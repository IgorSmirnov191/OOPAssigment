using System;

namespace HetDierenrijk
{
    internal class Reptile : Animal
    {
        public Reptile()
        {
            LaingEggs = true;
            NumbersOfScales = 4;
        }

        public bool LaingEggs { get; set; }
        public int NumbersOfScales { get; set; }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"Extra Features: " +
                $"Laing Eggs({LaingEggs})," +
                 $"Numbers Of Scales({NumbersOfScales})");
        }
    }
}