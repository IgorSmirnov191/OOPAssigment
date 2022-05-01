using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetDierenrijk
{
    internal class Animal
    {
        public Animal()
        {
            AbleToMove = true;
            ConsumeOrganic  = true;
            BreatheOxygen = true;
            ReproduceSexually = true;
        }
        public bool AbleToMove { get; set; }
        public bool ConsumeOrganic { get; set; }
        public bool BreatheOxygen { get; set; }
        public bool ReproduceSexually { get; set; }

        public virtual void ToonInfo(){
            Console.WriteLine($"Features: " +
                $"AbleToMove({AbleToMove})," +
                 $"ConsumeOrganic({ConsumeOrganic})," +
                  $"BreatheOxygen({BreatheOxygen})," +
                   $"ReproduceSexually({ReproduceSexually})");
        }
    }
}
