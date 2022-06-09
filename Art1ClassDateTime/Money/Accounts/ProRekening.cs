namespace Money
{
    public class ProRekening : SpaarRekening
    {
        public ProRekening() : base()
        {
        }

        public ProRekening(double basicCapital) : base(basicCapital)
        {
        }

        public override double BerekenRente()
        {
            return Saldo >= 1000 ? Saldo * 0.03 : base.BerekenRente();
        }
    }
}