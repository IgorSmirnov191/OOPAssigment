using System;

namespace BankManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Account account1 = new Account("Jos", 20, "000000001", AccountState.Geldig);
            Account account2 = new Account("Peter", 120, "000000002");
            Account account3 = new Account("Ivan", 200, "000000003", AccountState.Geldig);

            Console.WriteLine($"Klant naam: {account3.Name} Account status: {account3.AccountState}");
            account2.PayInFunds(100);
            account3.WithdrawFunds(50);

            int transfer = 100;
            account3.WithdrawFunds(transfer);
            account1.PayInFunds(transfer);
        }
    }
}