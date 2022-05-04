using System;

namespace HetDierenrijk
{
    internal class Mammal : Animal
    {
        public Mammal()
        {
            WarmBlooded = true;
            Tetrapoded = true;
            PresenceOfHair = true;
        }

        public bool WarmBlooded { get; set; }
        public bool Tetrapoded { get; set; }
        public bool PresenceOfHair { get; set; }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine($"Extra Features: " +
               $"Warm Blooded({WarmBlooded})," +
                $"Tetrapoded({Tetrapoded})," +
                 $"PresenceOfHair({PresenceOfHair})");
        }
    }
}