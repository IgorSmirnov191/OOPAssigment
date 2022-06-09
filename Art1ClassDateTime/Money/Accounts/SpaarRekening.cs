namespace Money
{
    public class SpaarRekening : Rekening
    {
        public SpaarRekening() : base()
        {
        }

        public SpaarRekening(double basicCapital) : base(basicCapital)
        {
        }

        public override double BerekenRente()
        {
            return Saldo * 0.02;
        }
    }
}