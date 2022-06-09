namespace Money
{
    public class NullRekening : IRekening
    {
        public NullRekening(double nullsaldo = 0.0)
        { }

        public string Name { get; set; } = "NoName";
        public string Number { get; set; } = "NoNumber";
        public bool IsLocked { get; set; } = true;
        public double Saldo { get; set; } = 0.0;

        public double BerekenRente()
        {
            return 0.0;
        }

        public double HaalGeldAf(double sum)
        {
            return 0.0;
        }

        public double VoegGeldToe(double sum)
        {
            return 0.0;
        }
    }
}