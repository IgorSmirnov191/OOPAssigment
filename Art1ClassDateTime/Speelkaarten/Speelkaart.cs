namespace Speelkaarten
{
    internal class Speelkaart
    {
        public int Digit { get; set; }
        public Suites Suit { get; set; }

        public Speelkaart()
        { }

        public Speelkaart(int digit, Suites suit)
        {
            Digit = digit;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"Kaart Getal:  {Digit}, Kleur {Suit} ";
        }
    }
}