namespace Money
{
    public interface IRekening
    {
        string Name { get; set; }
        string Number { get; set; }
        double Saldo { get; }
        double BerekenRente();
        double VoegGeldToe(double sum);
        double HaalGeldAf(double sum);
        bool IsLocked { get; set; }
    }
}