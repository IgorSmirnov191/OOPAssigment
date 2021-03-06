using System;

namespace Speelkaarten
{
    internal class Program
    {
        private static Random random = new Random();

        private static void Main(string[] args)
        {
            SpeelkaartenPak pak = new SpeelkaartenPak();

            for (int i = 1; i <= 13; i++)
            {
                foreach (Suites suit in Enum.GetValues(typeof(Suites)))
                {
                    pak.AddCard(new Speelkaart(i, suit));
                }
            }
            for (; ; )
            {
                if (pak.Count == 0) break;
                Speelkaart kaart = pak.TakeCard(random.Next(0, pak.Count - 1));
                Console.WriteLine(kaart.ToString());
            }
        }
    }
}