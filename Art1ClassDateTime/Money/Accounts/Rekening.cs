namespace Money
{
    public abstract class Rekening : IRekening
    {
        private double saldo;

        public double Saldo
        {
            get
            { return saldo; }
        }

        public Rekening()
        { }

        public Rekening(double basicCapital)
        {
            VoegGeldToe(basicCapital);
        }

        public abstract double BerekenRente();

        public double HaalGeldAf(double sum)
        {
            if (IsLocked)
            {
                return 0;
            }
            else
            {
                return (saldo -= (Saldo < sum) ? Saldo : sum);
            }
        }

        public double VoegGeldToe(double sum)
        {
            if (IsLocked)
            {
                return 0;
            }
            else
            {
                return saldo += sum;
            }
        }

        public bool IsLocked { get; set; } = false;
        public string Name { get; set; }
        public string Number { get; set; }
    }
}