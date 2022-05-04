using System;

namespace Meetlat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Meetlat mijnLat = new Meetlat();
            mijnLat.BeginLengte = 2;
            Console.WriteLine($"{mijnLat.LengteInM} meter is {mijnLat.LengteInVoet} voet.");

            mijnLat = new Meetlat(3);
            Console.WriteLine($"{mijnLat.LengteInM} meter is {mijnLat.LengteInVoet} voet.");
        }
    }
}