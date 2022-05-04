using System;

namespace Verjaardag
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Vaandag is {now.ToString("d")}");
            Console.WriteLine("Geef verjaardag in");
            bool correctInput = true;

            do
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDay))
                {
                    DateTime birthDayThisYear = new DateTime(now.Year, birthDay.Month, birthDay.Day);
                    TimeSpan diff = birthDayThisYear - now;
                    Console.WriteLine($"Aantal dagen voor(achter) jerjaardag = {diff.Days}");
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("Input fout. Geef verjaardag in");
                    correctInput = false;
                }
            } while (!correctInput);
        }
    }
}