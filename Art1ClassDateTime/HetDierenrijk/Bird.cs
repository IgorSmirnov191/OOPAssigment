using System;

namespace HetDierenrijk
{
    internal class Bird : Reptile
    {
        public Bird()
        {
            NumbersOfScales = 0;
            LightweightSkeleton = true;
            HaveWings = true;
        }

        public bool WarmBlooded { get; set; }
        public bool LightweightSkeleton { get; set; }
        public bool HaveWings { get; set; }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"Extra Features: " +
                $"Lightweight Skeleton({LightweightSkeleton})," +
                 $"Have Wings({HaveWings})");
        }
    }
}