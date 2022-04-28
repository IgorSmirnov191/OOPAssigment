using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetlat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Meetlat mijnLat = new Meetlat();
            mijnLat.BeginLengte = 2;
            Console.WriteLine($"{mijnLat.LengteInM} meter is {mijnLat.LengteInVoet} voet.");

            mijnLat = new Meetlat(3);
            Console.WriteLine($"{mijnLat.LengteInM} meter is {mijnLat.LengteInVoet} voet.");
        }
    }
}
