using System;

namespace BankManager
{
    public class Account
    {
        private string name;
        private int amount;
        private string number;
        private AccountState accountState;

        public Account(string name = "Unknown", int amount = 0, string number = "123456789",
            AccountState accountState = AccountState.Geblokkeerd)
        {
            this.name = name;
            this.amount = amount;
            this.number = number;
            this.accountState = accountState;
        }

        public string Name
        { get { return name; } set { name = value; } }

        public string Number
        { get { return number; } set { number = value; } }

        public AccountState AccountState
        { get { return accountState; } set { ChangeState(value); } }

        public void ChangeState(AccountState accountState)
        { this.accountState = accountState; }

        public int WithdrawFunds(int amount)
        {
            if (accountState == AccountState.Geblokkeerd)
            {
                amount = 0;
                Console.WriteLine($"Account Naam: {this.name} Geen transactie is mogelijk. Account is {accountState}");
            }
            else
            {
                amount = (amount < this.amount) ? amount : this.amount;
                this.amount -= amount;
                Console.WriteLine($"Account Naam: {this.name} Afgehalde bedrag: {amount}euro. Een nieuw saldo :{this.amount}euro");
            }

            return amount;
        }

        public int PayInFunds(int amount)
        {
            if (accountState == AccountState.Geblokkeerd)
            {
                amount = 0;
                Console.WriteLine($"Account Naam: {this.name} Geen transactie is mogelijk. Account is {accountState}");
            }
            else
            {
                this.amount += amount;
                Console.WriteLine($"Account Naam: {this.name} Gestorte bedrag: {amount}euro. Een nieuw saldo :{this.amount}euro");
            }

            return amount;
        }

        public int GetBalance()
        {
            return this.amount;
        }
    }
}