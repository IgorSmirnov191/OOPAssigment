namespace Money
{
    public class BankRekening : Rekening
    {
        public BankRekening() : base()
        {
        }

        public BankRekening(double basicCapital) : base(basicCapital)
        {
        }

        public override double BerekenRente()
        {
            if (Saldo > 100) return Saldo * 0.05;
            return 0;
        }
    }
}